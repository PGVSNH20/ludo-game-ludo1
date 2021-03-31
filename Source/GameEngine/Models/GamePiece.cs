using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GamePiece
    {
        public int GamePeaceId { get; set; }
        public GamePieceColor Color { get; set; }
        public int Number { get; set; }
        public int TrackPossition { get; set; }

        public List<GamePiece> GetGamePeaceSetUp()
        {
            var gamePeaceSetUp = new List<GamePiece>();
            for (int i = 0; i < 4; i++)
            {
                for (int y = 1; y <= 4; y++)
                {
                    gamePeaceSetUp.Add(new GamePiece()
                    {
                        Number = y,
                        Color = (GamePieceColor)i,
                        TrackPossition = 0
                    });
                }
            }
            return gamePeaceSetUp;
        }
    }

    public enum GamePieceColor
    {
        Blue,
        Red,
        Yellow,
        Green
    }
}