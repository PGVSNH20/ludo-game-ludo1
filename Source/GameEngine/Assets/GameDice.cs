using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameEngine.Assets
{
    public class GameDice
    {
        public Random Random { get; set; }
        public int Result { get; set; }

        public GameDice()
        {
            Random = new Random();
        }

        public void ThrowDice()
        {
            Result = Random.Next(1, 7);
            Console.WriteLine($"You got {Result}");
        }

        public void ThrowDice(GameColor color)
        {
            Result = Random.Next(1, 7);
            Tools.SetConsoleColor(color);
            RenderDiceTrow(Result);
            Console.ResetColor();
            Console.SetCursorPosition(45, 12);
            Console.WriteLine($"You got {Result}");
            Console.SetCursorPosition(0, 22);
        }

        public void RenderDiceTrow(int value)
        {
            for (int i = 0; i < 10; i++)
            {
                DicePrint(-1, 45, 14);
                Thread.Sleep(i * 21);
                DicePrint(0, 45, 14);
                Thread.Sleep((int)(i * 0.5 * 16));
            }
            DicePrint(value, 45, 14);
            Thread.Sleep(1000);
        }

        private void DicePrint(int version, int column, int row)
        {
            if (version == -1)
            {
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"   _______    ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  /\      \   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" / '\   .  \   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"/ ' '\______\  ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"\' ' / .  . /  ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" \' /      /   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  \/_'__'_/    ");
            }
            if (version == 0)
            {
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"   _______     ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  / .  . /\    ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" /      /' \   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"/_'__'_/' ' \  ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"\      \ ' '/  ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" \   .  \ '/   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  \_____ \/    ");
            }
            if (version == 1)
            {
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|       |\     ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|   o   |.\    ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|       | '|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|_______|. |   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" \ ' . ' \'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 2)
            {
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o     |\     ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|       |.\    ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|     o | '|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|_______|. |   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" \ ' . ' \'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 3)
            {
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o     |\     ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|   o   |.\    ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|     o | '|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|_______|. |   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" \ ' . ' \'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 4)
            {
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o   o |\     ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|       |.\    ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o   o |.'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|_______|.'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" \ ' . ' \'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 5)
            {
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o   o |\     ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|   o   |.\    ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o   o |.'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|_______|.'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" \ '   ' \'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 6)
            {
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o   o |\     ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o   o |.\    ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"| o   o | '|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"|_______|. |   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@" \ ' .   \'|   ");
                Console.SetCursorPosition(column, row++);
                Console.WriteLine(@"  \_____'_\|   ");
            }
        }
    }
}