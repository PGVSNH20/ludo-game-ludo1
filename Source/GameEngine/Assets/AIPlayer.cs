using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            var tmpPosition = (piece.TrackPosition == null) ? -1 : piece.TrackPosition;
            var boardTrackCellIndex = ((int)tmpPosition + 10 * (int)piece.Color) % 40;
            var maxThreatRangeIndex = (boardTrackCellIndex + 34) % 40;

            var boardTrackCellIndexBehind = boardTrackCellIndex;
            boardTrackCellIndexBehind = (boardTrackCellIndexBehind > maxThreatRangeIndex) ? boardTrackCellIndexBehind : boardTrackCellIndexBehind + 40;
            while (boardTrackCellIndexBehind >= maxThreatRangeIndex)
            {
                boardTrackCellIndexBehind--;
                var tmpBoardTrackCellIndex = boardTrackCellIndexBehind % 40;
                if (Board.MainTrack[tmpBoardTrackCellIndex] != null && Board.MainTrack[tmpBoardTrackCellIndex].Color != piece.Color)
                    return true;
            }
            return false;
        }

        public bool PieceIsThreatenedAtTargetPos(GamePiece piece)
        {
            var targetPosition = Tools.CalculateNewPositon(piece.TrackPosition, Dice.Result);
            var boardTrackCellIndex = (targetPosition + 10 * (int)piece.Color) % 40;
            var maxThreatRangeIndex = (boardTrackCellIndex + 34) % 40;

            var boardTrackCellIndexBehind = boardTrackCellIndex;
            boardTrackCellIndexBehind = (boardTrackCellIndexBehind > maxThreatRangeIndex) ? boardTrackCellIndexBehind : boardTrackCellIndexBehind + 40;
            while (boardTrackCellIndexBehind >= maxThreatRangeIndex )
            {
                boardTrackCellIndexBehind--; //TODO får inte vara noll
                var tmpBoardTrackCellIndex = boardTrackCellIndexBehind % 40;
                if (Board.MainTrack[tmpBoardTrackCellIndex] != null && Board.MainTrack[tmpBoardTrackCellIndex].Color != piece.Color)
                    return true;
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