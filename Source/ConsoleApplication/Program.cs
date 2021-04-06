﻿using GameEngine;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GameRunner game = new GameRunner();
            Console.WriteLine("Welcome to Ludo!");

            Console.WriteLine("Menu\n" +
                "1) Start new game\n" +
                "2) Load game\n" +
                "3) Exit game");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    game.CreateNewGame();
                    game.PlayGame();
                    break;
                case "2":
                    
                    break;
                case "3":

                    break;
                default:

                    break;
            }
        }    
    }
}
