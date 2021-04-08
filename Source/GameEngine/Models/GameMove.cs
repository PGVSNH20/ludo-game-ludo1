using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GameMove
    {
        public int GameMoveID { get; set; }
        public GamePlayer Player { get; set; }
        public GamePiece Piece { get; set; }
        public int? OriginalPosition { get; set; }
        public int DiceThrowResult { get; set; }
        public DateTime Created { get; set; }
    }
}