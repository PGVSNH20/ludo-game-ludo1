using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GameBoard
    {
        public GamePiece[] Track { get; set; }
        public GameBoard()
        {
            Track = new GamePiece[40];
        }
    }
}
