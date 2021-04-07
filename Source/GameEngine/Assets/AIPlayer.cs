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

        public AIPlayer(GameBoard board, List<GamePiece> gamePeaceSetUp)
        {
            Board = board;
            GamePeaceSetUp = gamePeaceSetUp;
        }

        //public string ChoosePieceToMove(GameColor color, int diceResult)
        //{
        //    var movablePieces = Tools.GetMovableGamePieces(GamePeaceSetUp, color, diceResult);

        //    //Prio list (Dictionary<GamePiece, PrioInt)
        //    var prioGamePieces = new Dictionary<GamePiece, int>();
        //    foreach (var piece in movablePieces)
        //    {
        //        prioGamePieces.Add(piece, 0);
        //    }
        //    var maxPosition = prioGamePieces.Keys.Max(p => p.TrackPosition);
        //    var maxPositionPiece = prioGamePieces.Where(k => k.Key.TrackPosition == maxPosition).ToList();

        //    foreach (var piece in prioGamePieces.Keys)
        //    {
        //        if (piece.TrackPosition == null)
        //            prioGamePieces[piece]++;
        //    }
        //    int? minValue = null;

        //    //Thread.Sleep(100);
        //    return availableGamePieces.Find(p => p.Possition == minValue).Number.ToString();
        //}
    }
}