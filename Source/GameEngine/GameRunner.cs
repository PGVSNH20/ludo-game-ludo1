using GameEngine.Assets;
using GameEngine.DatabaseContext;
using GameEngine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GameRunner
    {
        public LudoGame Game { get; set; }
        public GameDice Dice { get; set; }
        public GameBoard Board { get; set; }
        public bool DbConnectionIsActive { get; set; }
        private GamePiece OponentsGamePiece { get; set; }
        private GameAI AI { get; set; }
        private Task SaveNewGameTask { get; set; }

        public GameRunner()
        {
            Dice = new GameDice();
            Board = new GameBoard();
            DbConnectionIsActive = true;
        }

        public GameRunner CreateNewGame()
        {
            // Player chooses amount of players

            Game = new LudoGame()
            {
                Created = DateTime.Now
            };
            Game.GamePlayers.Players = new List<GamePlayer>();
            Game.Moves = new List<GameMove>();
            Game.Status = "Created";
            Game.GameName = InputDialogs.GetGameName();
            int playerAmount = InputDialogs.GetPlayerAmount();
            Game.GamePlayers.Players = InputDialogs.GetPlayers(playerAmount);

            int startingPlayerIndex = new Random().Next(0, Game.GamePlayers.Players.Count);
            Game.NextPlayer = Game.GamePlayers.Players[startingPlayerIndex];

            Game.PieceSetup = Tools.GetGamePieceSetup(Game.GamePlayers.Players);
            Board.UpdateBoardBases(Game.PieceSetup);

            if (DbConnectionIsActive)
            {
                var db = new LudoGameDbContext();
                SaveNewGameTask = new Task(() => SaveGameToDataBase(db));
                SaveNewGameTask.Start();
            }

            return this;
        }

        public GameRunner LoadGameFromDataBase()
        {
            if (DbConnectionIsActive)
            {
                var db = new LudoGameDbContext();
                var allGames = LoadAllGamesFromDataBase(db);
                var oneLudoGame = InputDialogs.GetLudoGame(allGames);
                LoadGameFromDatabase(oneLudoGame, db);
                Board.UpdateTracks(Game.PieceSetup);
            }
            else Console.WriteLine("Db connections is not active");

            return this;
        }

        public GameRunner LoadGameFromFile(string fileName)
        {
            Game = FileHandler.ReadFromFile(fileName);
            if (DbConnectionIsActive)
            {
                var db = new LudoGameDbContext();
                if (!db.Games.Contains(Game))
                {
                    Game = Tools.DeepCloneGame(Game);
                    DbTransactionWrapper(db, db => SaveGameToDataBase(db));
                }
            }

            Board.UpdateTracks(Game.PieceSetup);
            return this;
        }

        public GameRunner ToogleDbConnection(bool status)
        {
            DbConnectionIsActive = status;
            return this;
        }

        public void PlayGame()

        {
            if (Game.GamePlayers.Players.FindAll(p => p.Type == (PlayerType)1).Count > 0)
                AI = new GameAI(Board, Game.PieceSetup, Dice);
            var alive = true;
            while (alive && Game.Winer == null)
            {
                var playerChoise = InputDialogs.GetPlayerMenuChoise(Game, Board);

                switch (playerChoise)
                {
                    case "1":

                        Dice.ThrowDice(Game.NextPlayer.Color); //animation (true if color param)
                        GamePiece gamePieceToMove = null;

                        if (Game.NextPlayer.Type == (PlayerType)1)
                            gamePieceToMove = AI.ChoosePieceToMove(Game.NextPlayer.Color, Dice.Result);
                        else
                            gamePieceToMove = InputDialogs.GetGamePieceToMove(Game.PieceSetup, Game.NextPlayer.Color, Dice.Result);

                        CreateMove(gamePieceToMove);
                        if (Game.Moves.Last().Piece != null)
                            ExecuteMove();
                        break;

                    case "2":
                        FileHandler.WriteToFile($"{Game.GameName}_{Game.LudoGameId}", Game);
                        Console.WriteLine($"Game saved to file {Game.GameName}_{Game.LudoGameId}.json");
                        Console.ReadKey();
                        break;

                    case "3":
                        //Spel är uppdaterat i basen
                        alive = false;
                        break;
                }
                if (alive)
                {
                    if (Dice.Result != 6)
                    {
                        var currentPlayerIndex = Game.GamePlayers.Players.IndexOf(Game.NextPlayer);
                        var nextTurnPlayerIndex = (currentPlayerIndex + 1) % (Game.GamePlayers.Players.Count());
                        Game.NextPlayer = Game.GamePlayers.Players[nextTurnPlayerIndex];
                    }
                    else
                    {
                        Console.WriteLine("Congratulations you can roll again!");
                        if (Game.NextPlayer.Type == (PlayerType)1)
                            Thread.Sleep(1000);
                        else
                            Console.ReadKey();
                    }
                    if (DbConnectionIsActive)
                    {
                        var db = new LudoGameDbContext();
                        DbTransactionWrapper(db, db => SaveMoveToDataBase(db));
                    }
                }
            }
            if (Game.Winer != null)
            {
                Console.WriteLine($"{Game.Winer} wins!");
                Console.ReadKey();
            }
        }

        private void CreateMove(GamePiece gamePieceToMove)
        {
            var currentMove = new GameMove()
            {
                Player = Game.NextPlayer,
                Piece = null,
                OriginalPosition = null,
                DiceThrowResult = Dice.Result,
                Created = DateTime.Now
            };

            if (gamePieceToMove != null)
            {
                currentMove.Piece = gamePieceToMove;
                currentMove.OriginalPosition = gamePieceToMove.TrackPosition;
            }
            Game.Moves.Add(currentMove);
        }

        public void ExecuteMove()
        {
            var originalPosition = Game.Moves.Last().OriginalPosition;
            var currentGamePiece = Game.Moves.Last().Piece;
            var currentGameColor = Game.Moves.Last().Piece.Color;
            var currentPlayer = Game.Moves.Last().Player;
            var diceValue = Game.Moves.Last().DiceThrowResult;
            int newPosition = Tools.CalculateNewPositon(originalPosition, diceValue);

            //removes game piece from original cell

            if (originalPosition != null && originalPosition < 40)
            {
                //remove from track
                var originalBoardTrackCellIndex = ((int)originalPosition + 10 * (int)currentGameColor) % 40;
                Board.MainTrack[originalBoardTrackCellIndex] = null;
            }
            else if (originalPosition >= 40 && originalPosition < 44)
            {
                //remove from final track
                var originalFinalTrackCellIndex = (int)originalPosition - 40;
                Board.FinalTracks[(int)currentGameColor][originalFinalTrackCellIndex] = null;
            }

            //add game piece to target cell

            if (newPosition < 40)
            {
                //add to track
                var targetBoardTrackCellIndex = ((int)newPosition + 10 * (int)currentGameColor) % 40;
                var tmpCell = Board.MainTrack[targetBoardTrackCellIndex];
                if (tmpCell != null)
                {
                    //update position av opponents piece
                    if (tmpCell.Color != currentGameColor)
                    {
                        OponentsGamePiece = tmpCell;
                        tmpCell.TrackPosition = null;
                        Console.WriteLine($"{currentGameColor} {currentGamePiece.Number} kicked out {OponentsGamePiece.Color} {OponentsGamePiece.Number}!");

                        Thread.Sleep(1000);
                    }
                }
                Board.MainTrack[targetBoardTrackCellIndex] = currentGamePiece;
            }
            else if (newPosition >= 40 && newPosition < 44)
            {
                //add to final track
                var targetFinalTrackCellIndex = (int)newPosition - 40;
                Board.FinalTracks[(int)currentGameColor][targetFinalTrackCellIndex] = currentGamePiece;
            }
            //update piece position
            currentGamePiece.TrackPosition = newPosition;
            Game.Status = $"In progress (moves {Game.Moves.Count})";

            if (newPosition == 44)
            {
                currentGamePiece.TrackPosition = 45;
                Console.WriteLine($"{currentGameColor} {currentGamePiece.Number} finished!");
                if (Game.NextPlayer.Type == (PlayerType)1)
                    Thread.Sleep(1000);
                else
                    Console.ReadKey();

                var piecesAtFinish = Game.PieceSetup.Where(p => p.Color == currentGameColor && p.TrackPosition == 45).Count();
                if (piecesAtFinish == 4)
                {
                    Game.Winer = currentPlayer;
                    Game.Status = $"Finished";
                }
            }
        }

        public bool SaveMoveToDataBase(LudoGameDbContext db)
        {
            if (SaveNewGameTask != null && SaveNewGameTask.Status == TaskStatus.Running)
                SaveNewGameTask.Wait();
            GamePiece gamePiece = null;
            if (Game.Moves.Last().Piece != null)
            {
                gamePiece = db.GamePieces.Where(p => p == Game.Moves.Last().Piece).Single();
                gamePiece.TrackPosition = Game.Moves.Last().Piece.TrackPosition;
                db.GamePieces.Update(gamePiece);
                db.SaveChanges();
            }

            if (OponentsGamePiece != null)
            {
                var oponentsGamePiece = db.GamePieces.Where(p => p.GamePieceId == OponentsGamePiece.GamePieceId).Single();
                oponentsGamePiece.TrackPosition = OponentsGamePiece.TrackPosition;
                OponentsGamePiece = null;
                db.GamePieces.Update(oponentsGamePiece);
                db.SaveChanges();
            }

            if (db.GameMoves.Where(m => m == Game.Moves.Last()).ToList().Count == 0)
            {
                var nextPlayer = db.Players.Where(p => p == Game.NextPlayer).Single();
                var moveOwnerPlayer = db.Players.Where(p => p == Game.Moves.Last().Player).Single();

                var game = db.Games.Where(g => g == Game).Include("Moves").Single();

                game.Moves.Add(Game.Moves.Last());
                game.NextPlayer = nextPlayer;
                game.Status = Game.Status;
                game.LastPlayed = DateTime.Now;
                if (Game.Winer != null)
                {
                    var winer = db.Players.Where(p => p == Game.Winer).Single();
                    game.Winer = winer;
                }
                game.Moves.Last().Player = moveOwnerPlayer;
                game.Moves.Last().Piece = gamePiece;
                db.Games.Update(game);
                db.SaveChanges();
            }
            return true;
        }

        public bool SaveGameToDataBase(LudoGameDbContext db)
        {
            db.Games.Add(Game);
            db.SaveChanges();
            return true;
        }

        public void DbTransactionWrapper(LudoGameDbContext db, Func<LudoGameDbContext, bool> dbExecution)
        {
            using var transaction = db.Database.BeginTransaction();
            dbExecution(db);
            transaction.Commit();
        }

        public void LoadGameFromDatabase(LudoGame ludoGame, LudoGameDbContext db)
        {
            Game = db.Games
                    .Where(g => g == ludoGame)
                    .Include(g => g.GamePlayers)
                    .Include(g => g.Moves)
                    .Include(g => g.PieceSetup)
                    .SingleOrDefault();

            var gamePlayers = db.PlayersInGame
                    .Where(pig => pig.GamePlayersId == Game.LudoGameId)
                    .Include("Players")
                    .Single();

            var id = Game.LudoGameId;
            Game.GamePlayers = gamePlayers;
        }

        public List<LudoGame> LoadAllGamesFromDataBase(LudoGameDbContext db)
        {
            List<LudoGame> ludoGames = db.Games.Where(g => g.Winer == null).AsNoTracking().ToList();
            return ludoGames;
        }
    }
}