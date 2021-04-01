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

        internal string ChoosePieceToMove(GameColor color)
        {
            var currentGamePieces = GamePeaceSetUp.Where(p => p.Color == color).ToList();
            int? minValue = null;
            if (currentGamePieces.FindAll(p => p.Possition == null).Count == 0)
                minValue = currentGamePieces.Min(p => p.Possition);

            Thread.Sleep(100);
            return (currentGamePieces.IndexOf(currentGamePieces.Find(p => p.Possition == minValue)) + 1).ToString();
        }
    }
}