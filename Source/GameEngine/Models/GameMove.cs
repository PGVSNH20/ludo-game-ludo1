namespace GameEngine.Models
{
    public class GameMove
    {
        public int GameMoveId { get; set; }
        public Player Player { get; set; }
        public GamePeace GamePeace { get; set; }
        public int OriginalPosition { get; set; }
        public int DiceThrow { get; set; }
    }
}