using System;
using System.Collections.Generic;

namespace GameEngine.Models
{
    public class GameDice
    {
        public List<int> ThrowValues { get; set; }
        public Random Random { get; set; }
        public int Result { get => result; }
        public int result { get; set; }

        public GameDice()
        {
            Random = new Random();
            ThrowValues = new List<int>();
        }

        public void TrowDice()
        {
            result = Random.Next(1, 7);
            ThrowValues.Add(result);
        }
    }
}