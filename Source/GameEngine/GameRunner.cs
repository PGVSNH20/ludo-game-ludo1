using GameEngine.Models;
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

        public GameRunner()
        {
            Dice = new GameDice();
            Board = new GameBoard();
        }

        public GameRunner CreateNewGame()
        {
            // Player chooses amount of players

            Game = new LudoGame();
            Game.Players = new List<GamePlayer>();
            Game.Moves = new List<GameMove>();

            int playerAmmount = GetPlayerAmount();
            GetPlayersProperties(playerAmmount);
            Game.Players = Game.Players.OrderBy(p => p.GamePlayerColour).ToList();
            int startingPlayerIndex = new Random().Next(0, Game.Players.Count);
            Game.NextTurnPlayer = Game.Players[startingPlayerIndex];

            Game.PieceSetup = GamePiece.GetGamePieceSetup(Game.Players);
            Board.UpdateBoardBases(Game.PieceSetup);
            return this;
        }

        private void GetPlayersProperties(int playerAmmount)
        {
            var availableColors = new List<GameColor>() { 0, (GameColor)1, (GameColor)2, (GameColor)3 };

            for (int i = 0; i < playerAmmount; i++)
            {
                var newPlayer = new GamePlayer();

                // Player chooses name

                var playerName = $"Player {i + 1}";
                Console.WriteLine($"Player {i + 1} choose a name: ");
                newPlayer.GamePlayerName = Console.ReadLine();

                if (newPlayer.GamePlayerName == "")
                {
                    newPlayer.GamePlayerName = playerName;
                }

                // Player chooses color
                Console.WriteLine($"{newPlayer.GamePlayerName} choose a color:");

                for (int y = 0; y < availableColors.Count; y++)
                {
                    Console.WriteLine($"{y + 1}) {availableColors[y]}");
                }
                var colorsLeft = availableColors.Count;
                while (colorsLeft == availableColors.Count)
                    try
                    {
                        var input = Console.ReadLine();
                        if (input == "")
                            input = "1";
                        var playerColorInput = Convert.ToInt32(input) - 1;
                        newPlayer.GamePlayerColour = availableColors[playerColorInput];
                        availableColors.Remove(availableColors[playerColorInput]);
                    }
                    catch
                    {
                        Console.WriteLine("Input not accepted, choose an available color");
                    }

                // Add player to game players
                Game.Players.Add(newPlayer);
            }
        }

        private int GetPlayerAmount()
        {
            int playerAmmount = 0;
            while (playerAmmount < 2 || playerAmmount > 4)
            {
                Console.WriteLine("Choose how many players: ");
                try
                {
                    playerAmmount = Convert.ToInt32(Console.ReadLine().Trim());
                    if (playerAmmount < 2 || playerAmmount > 4)
                        Console.WriteLine("Choose between 2 and 4");
                    Console.WriteLine($"{playerAmmount} players will play!");
                }
                catch { Console.WriteLine("Input not accepted. Choose between 2 and 4"); }
            }
            return playerAmmount;
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
                Console.WriteLine($"Now it's {Game.NextTurnPlayer.GamePlayerName} turn\n" +
                    $"1) Throw dice\n" +
                    $"2) Save game");

                var input = Console.ReadLine();
                input = (input == "") ? "1" : input;

                switch (input)
                {
                    case "1":

                        Dice.ThrowDice();
                        var gamePieceToMove = GetGamePieceToMove();
                        CreateNewMove(gamePieceToMove);
                        if (Game.Moves.Last().Piece != null)
                            ExecuteLastMove();
                        break;

                    case "2":
                        //Sparar spel
                        break;
                }
                if (Dice.LastResult != 6)
                {
                    var currentPlayerIndex = Game.Players.IndexOf(Game.NextTurnPlayer);
                    var nextTurnPlayerIndex = (currentPlayerIndex + 1) % (Game.Players.Count());
                    Game.NextTurnPlayer = Game.Players[nextTurnPlayerIndex];
                }
            }
        }

        public void ExecuteLastMove()
        {
            var originalPosition = Game.Moves.Last().OriginalPosition;
            var currentGamePiece = Game.Moves.Last().Piece;
            var currentGameColor = Game.Moves.Last().Piece.Color;
            var currentPlayer = Game.Moves.Last().Player;
            var diceValue = Game.Moves.Last().DiceThrowResult;
            int newPosition = CalculateNewPositon(originalPosition, diceValue);

            //removes game piece from original cell

            if (originalPosition != null && originalPosition < 40)
            {
                //remove from track
                var originalBoardTrackCellIndex = (int)originalPosition + 10 * (int)currentGameColor % 40;
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
                var targetBoardTrackCellIndex = (int)newPosition + 10 * (int)currentGameColor % 40;
                var tmpCell = Board.MainTrack[targetBoardTrackCellIndex];
                if (tmpCell != null)
                {
                    //update position av opponents piece
                    if (tmpCell.Color != currentGameColor)
                        tmpCell.TrackPosition = null;
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
                var piecesAtFinish = Game.PieceSetup.Where(p => p.Color == currentGameColor && p.TrackPosition == 44).Count();
                if (piecesAtFinish == 4)
                {
                    Game.Winner = currentPlayer;
                }
            }
        }

        private int CalculateNewPositon(int? originalPosition, int diceValue)
        {
            var newPosition = (originalPosition == null) ? diceValue - 1 : (int)originalPosition + diceValue;
            newPosition = (newPosition > 44) ? 88 - newPosition : newPosition;
            return newPosition;
        }

        private GamePiece GetGamePieceToMove()
        {
            GamePiece gamePieceToMove = null;
            List<GamePiece> movablePieces = GetMovableGamePieces();
            if (movablePieces.Count != 0)
            {
                Console.WriteLine("Choose your game piece:");
                for (int i = 0; i < movablePieces.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) Piece number: {movablePieces[i].Number} at position {movablePieces[i].TrackPosition + 1}");
                }
                // TODO: Input check
                var chosenPieceIndex = int.Parse(Console.ReadLine()) - 1;
                gamePieceToMove = movablePieces[chosenPieceIndex];
            }
            else
            {
                Console.WriteLine($"You don't have available moves based on dice result");
                Console.ReadKey();
            }
            return gamePieceToMove;
        }

        private void CreateNewMove(GamePiece pieceToMove)
        {
            var currentMove = new GameMove()
            {
                Player = Game.NextTurnPlayer,
                Piece = null,
                OriginalPosition = null,
                DiceThrowResult = Dice.LastResult
            };

            if (pieceToMove != null)
            {
                currentMove.Piece = pieceToMove;
                currentMove.OriginalPosition = pieceToMove.TrackPosition;
            }
            Game.Moves.Add(currentMove);
        }

        public List<GamePiece> GetMovableGamePieces()
        {
            //List of Pieces of same color
            var playerPieces = Game.PieceSetup.Where(p => p.Color == Game.NextTurnPlayer.GamePlayerColour).ToList();
            var movablePieces = new List<GamePiece>();
            if (Dice.LastResult != 1 && Dice.LastResult != 6)
            {
                //List of Pieces of same color that are not att null (base)
                playerPieces = playerPieces.Where(p => p.TrackPosition != null).ToList();
            }

            if (playerPieces.Count > 0)
            {
                for (int i = 0; i < playerPieces.Count(); i++)
                {
                    //iteration throe available pieces to se if specifik piece can be moved to target position
                    //piece can not be places att position witch already contains piece of same color
                    //piece can not jump over another piece of same color
                    var originalPosition = playerPieces[i].TrackPosition;
                    var positionAhead = (originalPosition == null) ? -1 : originalPosition;
                    var potencialTrackPosition = CalculateNewPositon(originalPosition, Dice.LastResult);
                    while (positionAhead <= potencialTrackPosition)
                    {
                        positionAhead++;
                        if (playerPieces.FindAll(p => p.TrackPosition == positionAhead).Count > 0)
                            break;

                        if (playerPieces.FindAll(p => p.TrackPosition == potencialTrackPosition).Count == 0 && positionAhead == potencialTrackPosition)
                            movablePieces.Add(playerPieces[i]);
                    }
                }
            }

            return movablePieces;
        }
    }
}