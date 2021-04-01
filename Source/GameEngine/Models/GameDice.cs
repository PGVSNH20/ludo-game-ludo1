using System;
using System.Collections.Generic;

namespace GameEngine.Models
{
    public class GameDice
    {
        public List<int> ThrowValues { get; set; }
        public Random Random { get; set; }
        public int Result { get => result; }
        private int result { get; set; }

        public GameDice()
        {
            Random = new Random();
            ThrowValues = new List<int>();
        }

        public void TrowDice()
        {
            result = Random.Next(1, 6);
            ThrowValues.Add(result);
        }
    }
}