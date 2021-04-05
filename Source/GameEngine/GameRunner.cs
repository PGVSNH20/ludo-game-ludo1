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
                        ExecuteLastMove();
                        break;
                }
            }
        }

        private void ExecuteLastMove()
        {
            var originalPosition = Game.Moves.Last().OriginalPosition;
            var currentGamePiece = Game.Moves.Last().Piece;
            var currentGameColor = Game.Moves.Last().Piece.Color;
            var currentPlayer = Game.Moves.Last().Player;
            var diceValue = Game.Moves.Last().DiceThrowValue;
            int newPosition = (originalPosition == null) ? diceValue : (int)originalPosition + diceValue;
            newPosition = (newPosition > 44) ? 88 - newPosition : newPosition;

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

        private void CreateNewMove()
        {
            var playersPieces = Game.PieceSetup.Where(p => p.Color == Game.NextTurnPlayer.GamePlayerColour).ToList();
            Console.WriteLine("Choose your game piece:");
            foreach (var gamePiece in playersPieces)
            {
                Console.WriteLine($"Piece number: {gamePiece.Number} at position {gamePiece.TrackPosition}");
            }
            var chosenPieceIndex = int.Parse(Console.ReadLine());
            var currentMove = new GameMove()
            {
                Player = Game.NextTurnPlayer,
                Piece = playersPieces[chosenPieceIndex],
                OriginalPosition = playersPieces[chosenPieceIndex].TrackPosition,
                DiceThrowValue = Dice.LastResult
            };
            Game.Moves.Add(currentMove);
        }
    }
}