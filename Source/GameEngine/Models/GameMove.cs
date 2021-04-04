﻿namespace GameEngine.Models
{
    public class GameMove
    {
        public int GameMoveId { get; set; }
        public GamePlayer Player { get; set; }
        public GamePiece GamePiece { get; set; }
        public int? OriginalPosition { get; set; }
        public int DiceThrow { get; set; }
    }
}