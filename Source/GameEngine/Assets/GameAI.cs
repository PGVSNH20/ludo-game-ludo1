using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameEngine.Assets
{
    public class GameAI
    {
        public GameBoard Board { get; set; }
        public List<GamePiece> GamePeaceSetUp { get; set; }
        public GameDice Dice { get; set; }

        public GameAI(GameBoard board, List<GamePiece> gamePeaceSetUp, GameDice dice)
        {
            Board = board;
            GamePeaceSetUp = gamePeaceSetUp;
            Dice = dice;
        }

        public GamePiece ChoosePieceToMove(GameColor color, int diceResult)
        {
            Thread.Sleep(100);
            var movablePieces = Tools.GetMovableGamePieces(GamePeaceSetUp, color, diceResult);

            if (movablePieces.Count > 0)
            {
                //Prio list (Dictionary<GamePiece, PrioInt)
                var prioGamePieces = new Dictionary<GamePiece, int>();
                foreach (var piece in movablePieces)
                {
                    prioGamePieces.Add(piece, 0);

                    if (GamePieceCanKick(piece))
                        prioGamePieces[piece] += 2;

                    if (piece.TrackPosition == null)
                        prioGamePieces[piece] += 2;
                    if (PieceIsThreatenedAtOriginPos(piece))
                        prioGamePieces[piece] += 2;
                    if (PieceIsThreatenedAtTargetPos(piece))
                        prioGamePieces[piece] -= 1;
                }

                return prioGamePieces.OrderByDescending(p => p.Value).First().Key;
            }
            return null;
        }

        public bool PieceIsThreatenedAtOriginPos(GamePiece piece)
        {
            var pos = (piece.TrackPosition == null) ? -1 : piece.TrackPosition;
            var index = ((int)pos + 10 * (int)piece.Color) % 40;
            var minIndex = (index + 34) % 40;

            var indexBehind = index - 1;
            indexBehind = (indexBehind > minIndex) ? indexBehind : indexBehind + 40;
            while (indexBehind >= minIndex)
            {
                var tmpIndex = indexBehind % 40;
                if (Board.MainTrack[tmpIndex] != null && Board.MainTrack[tmpIndex].Color != piece.Color)
                    return true;
                indexBehind--;
            }
            return false;
        }

        public bool PieceIsThreatenedAtTargetPos(GamePiece piece)
        {
            var pos = Tools.CalculateNewPositon(piece.TrackPosition, Dice.Result);
            var index = (pos + 10 * (int)piece.Color) % 40;
            var minIndex = (index + 34) % 40;

            var indexBehind = index - 1;
            indexBehind = (indexBehind > minIndex) ? indexBehind : indexBehind + 40;
            while (indexBehind >= minIndex)
            {
                var tmpIndex = indexBehind % 40;
                if (Board.MainTrack[tmpIndex] != null && Board.MainTrack[tmpIndex].Color != piece.Color)
                    return true;
                indexBehind--;
            }
            return false;
        }

        public bool GamePieceCanKick(GamePiece piece)
        {
            var originalPosition = piece.TrackPosition;
            var potencialTrackPosition = Tools.CalculateNewPositon(originalPosition, Dice.Result);

            if (potencialTrackPosition < 40)
            {
                var targetBoardTrackCellIndex = ((int)potencialTrackPosition + 10 * (int)piece.Color) % 40;
                if (Board.MainTrack[targetBoardTrackCellIndex] != null && Board.MainTrack[targetBoardTrackCellIndex].Color != piece.Color)
                    return true;
            }
            return false;
        }
    }
}