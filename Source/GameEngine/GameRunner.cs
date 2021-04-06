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

        public void CreateNewGame()
        {
            Game = new LudoGame();
            Game.Players = new List<GamePlayer>();
            for (int i = 0; i < 3; i++)
            {
                Game.Players.Add(new GamePlayer()
                {
                    GamePlayerName = $"Player {i + 1}",
                    GamePlayerColour = (GameColor)i
                });
            }

            Game.PieceSetup = GamePiece.GetGamePieceSetup();

            int startingPlayerIndex = new Random().Next(0, Game.Players.Count);

            Game.NextTurnPlayer = Game.Players[startingPlayerIndex];

            Game.Moves = new List<GameMove>();
        }

        public void LoadGame()
        {
            //get game from db
        }

        public void PlayGame()
        {
            while (Game.Winner == null)
            {
                Console.WriteLine($"Now it's {Game.NextTurnPlayer.GamePlayerName} turn\n" +
                    $"1) Throw dice\n" +
                    $"2) Save game");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Dice.ThrowDice();
                        CreateNewMove();
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
                    var nextTurnPlayerIndex = currentPlayerIndex + 1 % (Game.Players.Count() - 1);
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
                Board.Track[originalBoardTrackCellIndex] = null;
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
                var tmpCell = Board.Track[targetBoardTrackCellIndex];
                if (tmpCell != null)
                {
                    //update position av opponents piece
                    if (tmpCell.Color != currentGameColor)
                        tmpCell.TrackPosition = null;
                }
                Board.Track[targetBoardTrackCellIndex] = currentGamePiece;
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
            var newPosition = (originalPosition == null) ? diceValue : (int)originalPosition + diceValue;
            newPosition = (newPosition > 44) ? 88 - newPosition : newPosition;
            return newPosition;
        }

        private void CreateNewMove()
        {
            List<GamePiece> movablePieces = GetMovableGamePieces();

            if (movablePieces.Count == 0)
            {
                var currentMove = new GameMove()
                {
                    Player = Game.NextTurnPlayer,
                    Piece = null,
                    OriginalPosition = null,
                };
                Game.Moves.Add(currentMove);
            }
            else
            {
                Console.WriteLine("Choose your game piece:");
                foreach (var gamePiece in movablePieces)
                {
                    Console.WriteLine($"Piece number: {gamePiece.Number} at position {gamePiece.TrackPosition}");
                }
                var chosenPieceIndex = int.Parse(Console.ReadLine());

                var currentMove = new GameMove()
                {
                    Player = Game.NextTurnPlayer,
                    Piece = movablePieces[chosenPieceIndex],
                    OriginalPosition = movablePieces[chosenPieceIndex].TrackPosition,
                    DiceThrowResult = Dice.LastResult
                };
                Game.Moves.Add(currentMove);
            }
        }

        public List<GamePiece> GetMovableGamePieces()
        {
            var playersPieces = Game.PieceSetup.Where(p => p.Color == Game.NextTurnPlayer.GamePlayerColour).ToList();
            var movablePieces = new List<GamePiece>();
            if (Dice.LastResult != 1 && Dice.LastResult != 6)
            {
                playersPieces = playersPieces.Where(p => p.TrackPosition != null).ToList();
            }

            for (int i = 0; i < playersPieces.Count(); i++)
            {
                var originalPosition = playersPieces[i].TrackPosition;
                var positionAhead = originalPosition;
                var potencialTrackPosition = CalculateNewPositon(originalPosition, Dice.LastResult);
                while (positionAhead <= potencialTrackPosition)
                {
                    positionAhead++;
                    if (playersPieces.FindAll(p => p.TrackPosition == positionAhead).Count > 0)
                        break;

                    if (playersPieces.FindAll(p => p.TrackPosition == potencialTrackPosition).Count == 0 && positionAhead == potencialTrackPosition)
                        movablePieces.Add(playersPieces[i]);
                }
            }

            return movablePieces;
        }
    }
}