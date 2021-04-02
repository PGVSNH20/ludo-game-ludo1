using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameEngine
{
    public class AiPlayer
    {
        public GameBoard Board { get; set; }
        public List<GamePiece> GamePeaceSetUp { get; set; }

        public AiPlayer(GameBoard board, List<GamePiece> gamePeaceSetUp)
        {
            Board = board;
            GamePeaceSetUp = gamePeaceSetUp;
        }

        internal string ChoosePieceToMove(List<GamePiece> availableGamePieces)
        {
            int? minValue = null;
            if (availableGamePieces.FindAll(p => p.Possition == null).Count == 0)
                minValue = availableGamePieces.Min(p => p.Possition);

            Thread.Sleep(100);
            return availableGamePieces.Find(p => p.Possition == minValue).Number.ToString();
        }
    }
}