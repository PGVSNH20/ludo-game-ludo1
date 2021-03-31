using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GameDice
    {
        public int ThrowValue()
        {
            Random value = new Random();
            return value.Next(1, 7);
        }
    }
}
