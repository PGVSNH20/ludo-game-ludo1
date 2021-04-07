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

        public void ThrowDice(bool animation = false)
        {
            Result = Random.Next(1, 7);
            if (animation)
                RenderDiceTrow(Result);
            Console.WriteLine($"You got {Result}");
        }

        public void RenderDiceTrow(int value)
        {
            for (int i = 0; i < 10; i++)
            {
                DicePrint(-1, 16);
                Thread.Sleep(i * 15);
                DicePrint(0, 16);
                Thread.Sleep((int)(i * 0.5 * 16));
            }
            DicePrint(value, 16);
            Thread.Sleep(1000);
        }

        private void DicePrint(int version, int line)
        {
            if (version == -1)
            {
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"   _______    ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  /\      \   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" / '\   .  \   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"/ ' '\______\  ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"\' ' / .  . /  ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" \' /      /   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  \/_'__'_/    ");
            }
            if (version == 0)
            {
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"   _______     ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  / .  . /\    ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" /      /' \   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"/_'__'_/' ' \  ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"\      \ ' '/  ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" \   .  \ '/   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  \_____ \/    ");
            }
            if (version == 1)
            {
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|       |\     ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|   o   |.\    ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|       | '|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|_______|. |   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" \ ' . ' \'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 2)
            {
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o     |\     ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|       |.\    ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|     o | '|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|_______|. |   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" \ ' . ' \'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 3)
            {
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o     |\     ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|   o   |.\    ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|     o | '|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|_______|. |   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" \ ' . ' \'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 4)
            {
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o   o |\     ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|       |.\    ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o   o |.'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|_______|.'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" \ ' . ' \'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 5)
            {
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o   o |\     ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|   o   |.\    ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o   o |.'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|_______|.'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" \ '   ' \'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  \_'___'_\|   ");
            }
            if (version == 6)
            {
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" _______.      ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o   o |\     ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o   o |.\    ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"| o   o | '|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"|_______|. |   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@" \ ' .   \'|   ");
                Console.SetCursorPosition(20, line++);
                Console.WriteLine(@"  \_____'_\|   ");
            }
        }
    }
}