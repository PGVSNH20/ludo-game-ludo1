using GameEngine;
using System;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool alive = true;
            while (alive)
            {
                GameRunner game = new GameRunner();
                game.ToogleDbConnection(false);
                PrintMenu(13, 4);

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        game.CreateNewGame().PlayGame();
                        break;

                    case "2":
                        Console.Clear();
                        game.LoadGameFromDataBase().PlayGame();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Provide filename");
                        var fileName = Console.ReadLine();
                        game.LoadGameFromFile(fileName).PlayGame();
                        break;

                    case "4":
                        alive = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private static void PrintMenu(int columnFaktor, int lineFaktor)
        {
            Console.Clear();
            var column = columnFaktor;
            var line = lineFaktor;

            // "L"
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@" _    ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |   ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |   ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |   ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |___");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| ______");

            // "U"
            line = lineFaktor;
            column += 7;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@" _    _");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |  | ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |  | ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |  | ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |__| ");
            Console.SetCursorPosition(column + 1, line++);
            Console.WriteLine(@"\____/");

            // "D"
            line = lineFaktor;
            column += 7;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@" _____ ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"|  __ \");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |  | ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |  | ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |__| ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"|_____/");

            // "O"
            line = lineFaktor;
            column += 7;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"  ____ ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@" / __ \ ");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |  | |");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |  | |");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"| |__| |");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@" \____/");

            column = columnFaktor + 1;
            line = lineFaktor + 8;

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"1) Start new game");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"2) Load game from database");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"3) Load game from file");
            Console.SetCursorPosition(column, line++);
            Console.WriteLine(@"4) Exit game");
        }
    }
}