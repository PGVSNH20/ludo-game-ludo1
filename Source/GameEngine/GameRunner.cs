using GameEngine.Assets;
using GameEngine.DatabaseContext;
using GameEngine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class GameRunner
    {
        public LudoGame Game { get; set; }
        public GameDice Dice { get; set; }
        public GameBoard Board { get; set; }
        private GamePiece OponentsGamePiece { get; set; }

        public GameRunner()
        {
            Dice = new GameDice();
            Board = new GameBoard();
        }

        public GameRunner CreateNewGame()
        {
            // Player chooses amount of players

            Game = new LudoGame();
            Game.Players.Players = new List<GamePlayer>();
            Game.Moves = new List<GameMove>();

            int playerAmount = Tools.GetPlayerAmount();
            Game.Players.Players = Tools.GetPlayers(playerAmount);

            int startingPlayerIndex = new Random().Next(0, Game.Players.Players.Count);
            Game.NextPlayer = Game.Players.Players[startingPlayerIndex];

            Game.PieceSetup = Tools.GetGamePieceSetup(Game.Players.Players);
            Board.UpdateBoardBases(Game.PieceSetup);
            SaveGameToDataBase();
            return this;
        }

        public GameRunner LoadGame()
        {
            //get game from db
            return this;
        }

        public void PlayGame()
        {
            while (Game.Winner == null)
            {
                Console.Clear();
                Board.PrintBoard(Game.PieceSetup);
                Console.Write($"Now it's ");
                Console.ForegroundColor = (ConsoleColor)Game.NextPlayer.Color;
                Console.Write(Game.NextPlayer.Name);
                Console.ResetColor();
                Console.WriteLine(" turn\n" + 
                    $"1) Throw dice\n" +
                    $"2) Save game");

                var input = Console.ReadLine();
                input = (input == "") ? "1" : input;

                switch (input)
                {
                    case "1":

                        Dice.ThrowDice();
                        var gamePieceToMove = Tools.GetGamePieceToMove(Game.PieceSetup, Game.NextPlayer.Color, Dice.Result);
                        CreateMove(gamePieceToMove);
                        if (Game.Moves.Last().Piece != null)
                            ExecuteMove();
                        break;

                    case "2":
                        //Sparar spel
                        break;
                }
                if (Dice.Result != 6)
                {
                    var currentPlayerIndex = Game.Players.Players.IndexOf(Game.NextPlayer);
                    var nextTurnPlayerIndex = (currentPlayerIndex + 1) % (Game.Players.Players.Count());
                    Game.NextPlayer = Game.Players.Players[nextTurnPlayerIndex];
                }
                else
                {
                    Console.WriteLine("Congratulations you can roll again!");
                    Console.ReadKey();
                }
                // SaveMoveToDataBase();
            }
            //spelet är slut grattis!!!
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
                        Console.ReadKey();
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

            if (newPosition == 44)
            {
                currentGamePiece.TrackPosition = 45;
                Console.WriteLine($"{currentGameColor} {currentGamePiece.Number} finished!");
                Console.ReadKey();

                var piecesAtFinish = Game.PieceSetup.Where(p => p.Color == currentGameColor && p.TrackPosition == 45).Count();
                if (piecesAtFinish == 4)
                {
                    Game.Winner = currentPlayer;
                    Console.WriteLine($"{currentPlayer.Name} wins!");
                    Console.ReadKey();
                }
            }
        }

        private void CreateMove(GamePiece gamePieceToMove)
        {
            var currentMove = new GameMove()
            {
                Player = Game.NextPlayer,
                Piece = null,
                OriginalPosition = null,
                DiceThrowResult = Dice.Result
            };

            if (gamePieceToMove != null)
            {
                currentMove.Piece = gamePieceToMove;
                currentMove.OriginalPosition = gamePieceToMove.TrackPosition;
            }
            Game.Moves.Add(currentMove);
        }

        private void SaveMoveToDataBase()
        {
            var db = new LudoGameDbContext();
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

            var player = db.Players.Where(p => p == Game.NextPlayer).Single();
            var game = db.Games.Where(g => g == Game).Include("Moves").Single();

            game.Moves.Add(Game.Moves.Last());

            game.Moves.Last().Player = player;
            game.Moves.Last().Piece = gamePiece;
            db.Games.Update(game);
            // db.SaveChanges();
        }

        private void SaveGameToDataBase()
        {
            var db = new LudoGameDbContext();
            db.Games.Add(Game);
            db.SaveChanges();
        }

        private void LoadGameFromDatabase(LudoGame ludoGame)
        {
            var db = new LudoGameDbContext();
            Game = db.Games.Where(g => g == ludoGame)
                .Include(g => g.Players)
                .ThenInclude(p => p.Players)
                .Include(g => g.Moves)
                .Include(g => g.PieceSetup)
                .SingleOrDefault();
            
        }
        private List<LudoGame> LoadAllGamesFromDataBase()
        {
            var db = new LudoGameDbContext();
            List<LudoGame> ludoGames = db.Games.ToList();
            return ludoGames;
        }

    }
}