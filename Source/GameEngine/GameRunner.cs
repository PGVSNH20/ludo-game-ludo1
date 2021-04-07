using GameEngine.Assets;
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

            int playerAmmount = Tools.GetPlayerAmount();
            Game.Players = Tools.GetPlayers(playerAmmount);

            int startingPlayerIndex = new Random().Next(0, Game.Players.Count);
            Game.NextPlayer = Game.Players[startingPlayerIndex];

            Game.PieceSetup = Tools.GetGamePieceSetup(Game.Players);
            Board.UpdateBoardBases(Game.PieceSetup);
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
                Console.WriteLine($"Now it's {Game.NextPlayer.Name} turn\n" +
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
                    var currentPlayerIndex = Game.Players.IndexOf(Game.NextPlayer);
                    var nextTurnPlayerIndex = (currentPlayerIndex + 1) % (Game.Players.Count());
                    Game.NextPlayer = Game.Players[nextTurnPlayerIndex];
                }
            }
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

        private void CreateMove(GamePiece pieceToMove)
        {
            var currentMove = new GameMove()
            {
                Player = Game.NextPlayer,
                Piece = null,
                OriginalPosition = null,
                DiceThrowResult = Dice.Result
            };

            if (pieceToMove != null)
            {
                currentMove.Piece = pieceToMove;
                currentMove.OriginalPosition = pieceToMove.TrackPosition;
            }
            Game.Moves.Add(currentMove);
        }
    }
}