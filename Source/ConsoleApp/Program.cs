using GameEngine;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var LudoGame = new GameRunner().CreateNewGame().PlayGame();
        }
    }
}