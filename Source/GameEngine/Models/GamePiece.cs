using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GamePiece
    {
        public GameColor? Color { get; set; }
        public int Number { get; set; }
        public int? TrackPosition { get; set; }
    }
}