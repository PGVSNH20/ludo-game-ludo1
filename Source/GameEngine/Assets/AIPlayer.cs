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
                if (PieceIsThreatenedAtOriginPos(piece))
                    prioGamePieces[piece] += 2;
            }

            var maxPosition = prioGamePieces.Keys.Max(p => p.TrackPosition);
            var maxPositionPiece = prioGamePieces.Where(k => k.Key.TrackPosition == maxPosition).ToList();

            //Thread.Sleep(100);
            return prioGamePieces.First().Key;
        }

        public bool PieceIsThreatenedAtOriginPos(GamePiece piece)
        {
            var boardTrackCellIndex = ((int)piece.TrackPosition + 10 * (int)piece.Color) % 40;
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
            while (boardTrackCellIndexBehind >= maxThreatRangeIndex)
            {
                boardTrackCellIndexBehind--;
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