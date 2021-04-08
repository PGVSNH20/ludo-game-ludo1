using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Assets
{
    public class AIPlayer
    {
        public GameBoard Board { get; set; }
        public List<GamePiece> GamePeaceSetUp { get; set; }
        public GameDice Dice { get; set; }

        public AIPlayer(GameBoard board, List<GamePiece> gamePeaceSetUp, GameDice dice)
        {
            Board = board;
            GamePeaceSetUp = gamePeaceSetUp;
            Dice = dice;
        }

        public GamePiece ChoosePieceToMove(GameColor color, int diceResult)
        {
            var movablePieces = Tools.GetMovableGamePieces(GamePeaceSetUp, color, diceResult);

            //Prio list (Dictionary<GamePiece, PrioInt)
            var prioGamePieces = new Dictionary<GamePiece, int>();
            foreach (var piece in movablePieces)
            {
                prioGamePieces.Add(piece, 0);

                if (GamePieceCanKick(piece))
                    prioGamePieces[piece] += 2;

                if (piece.TrackPosition == null)
                    prioGamePieces[piece] += 1;
            }
            var maxPosition = prioGamePieces.Keys.Max(p => p.TrackPosition);
            var maxPositionPiece = prioGamePieces.Where(k => k.Key.TrackPosition == maxPosition).ToList();

            foreach (var piece in prioGamePieces.Keys)
            {
                if (piece.TrackPosition == null)
                    prioGamePieces[piece]++;
            }

            //Thread.Sleep(100);
            return prioGamePieces.First().Key;
        }

        public bool GamePieceCanKick(GamePiece piece)
        {
            var originalPosition = piece.TrackPosition;

            var positionAhead = (originalPosition == null) ? -1 : originalPosition;
            var potencialTrackPosition = Tools.CalculateNewPositon(originalPosition, Dice.Result);

            if (potencialTrackPosition < 40)
            {
                var targetBoardTrackCellIndex = ((int)potencialTrackPosition + 10 * (int)piece.Color) % 40;
                if (Board.MainTrack[targetBoardTrackCellIndex] != null)
                    return true;
            }
            return false;
        }
    }
}