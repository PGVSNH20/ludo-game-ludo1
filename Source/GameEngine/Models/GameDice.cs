using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GameDice
    {
        public Random Random { get; set; }
        public int LastResult { get; set; }

        public GameDice()
        {
            Random = new Random();
        }

        public void ThrowDice()
        {
            LastResult = Random.Next(1, 7);
            Console.WriteLine($"You got {LastResult}");
        }
    }
}