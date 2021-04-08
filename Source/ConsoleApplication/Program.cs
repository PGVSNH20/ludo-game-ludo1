using GameEngine;
using System;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
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
                    game.CreateNewGame().PlayGame();
                    break;

                case "2":
                    game.LoadGame().PlayGame();
                    //TODO Ladda alla spel som är inte klara
                    //TODO Presentera spel och välj en från user input
                    //TODO spela laddade spelet
                    break;

                case "3":

                    break;

                default:

                    break;
            }
        }
    }
}