using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GamePeace
    {
        public int GamePeaceId { get; set; }
        public GamePeaceColor Color { get; set; }
        public int Number { get; set; }
        public int TrackPossition { get; set; }

        public List<GamePeace> GetGamePeaceSetUp()
        {
            var gamePeaceSetUp = new List<GamePeace>();
            for (int i = 0; i < 4; i++)
            {
                for (int y = 1; y <= 4; y++)
                {
                    gamePeaceSetUp.Add(new GamePeace()
                    {
                        Number = y,
                        Color = (GamePeaceColor)i,
                        TrackPossition = 0
                    });
                }
            }
            return gamePeaceSetUp;
        }
    }

    public enum GamePeaceColor
    {
        Blue,
        Red,
        Yellow,
        Green
    }
}