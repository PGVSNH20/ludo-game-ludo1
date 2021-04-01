using System;

namespace GameEngine.Models
{
    public class GameBoard
    {
        public GamePiece[] Track { get; set; }
        public GamePiece[,] Board { get; set; }
        public GamePiece EmptyCell { get; set; }

        public GameBoard()
        {
            Track = new GamePiece[40];
            Board = new GamePiece[11, 11];
            EmptyCell = new GamePiece() { Number = 0 };

            for (int i = 0; i < 11; i++)
            {
                for (int y = 0; y < 11; y++)
                {
                    Board[i, y] = null;
                }
            }
        }

        public void PrintBoard()
        {
            Board[4, 10] = (Track[0] == null) ? EmptyCell : Track[0];
            Board[4, 9] = (Track[1] == null) ? EmptyCell : Track[1];
            Board[4, 8] = (Track[2] == null) ? EmptyCell : Track[2];
            Board[4, 7] = (Track[3] == null) ? EmptyCell : Track[3];
            Board[4, 6] = (Track[4] == null) ? EmptyCell : Track[4];

            Board[3, 6] = (Track[5] == null) ? EmptyCell : Track[5];
            Board[2, 6] = (Track[6] == null) ? EmptyCell : Track[6];
            Board[1, 6] = (Track[7] == null) ? EmptyCell : Track[7];
            Board[0, 6] = (Track[8] == null) ? EmptyCell : Track[8];

            Board[0, 5] = (Track[9] == null) ? EmptyCell : Track[9];

            Board[0, 4] = (Track[10] == null) ? EmptyCell : Track[10];
            Board[1, 4] = (Track[11] == null) ? EmptyCell : Track[11];
            Board[2, 4] = (Track[12] == null) ? EmptyCell : Track[12];
            Board[3, 4] = (Track[13] == null) ? EmptyCell : Track[13];
            Board[4, 4] = (Track[14] == null) ? EmptyCell : Track[14];

            Board[4, 3] = (Track[15] == null) ? EmptyCell : Track[15];
            Board[4, 2] = (Track[16] == null) ? EmptyCell : Track[16];
            Board[4, 1] = (Track[17] == null) ? EmptyCell : Track[17];
            Board[4, 0] = (Track[18] == null) ? EmptyCell : Track[18];

            Board[5, 0] = (Track[19] == null) ? EmptyCell : Track[19];

            Board[6, 0] = (Track[20] == null) ? EmptyCell : Track[20];
            Board[6, 1] = (Track[21] == null) ? EmptyCell : Track[21];
            Board[6, 2] = (Track[22] == null) ? EmptyCell : Track[22];
            Board[6, 3] = (Track[23] == null) ? EmptyCell : Track[23];
            Board[6, 4] = (Track[24] == null) ? EmptyCell : Track[24];

            Board[7, 4] = (Track[25] == null) ? EmptyCell : Track[25];
            Board[8, 4] = (Track[26] == null) ? EmptyCell : Track[26];
            Board[9, 4] = (Track[27] == null) ? EmptyCell : Track[27];
            Board[10, 4] = (Track[28] == null) ? EmptyCell : Track[28];

            Board[10, 5] = (Track[29] == null) ? EmptyCell : Track[29];

            Board[10, 6] = (Track[30] == null) ? EmptyCell : Track[30];
            Board[9, 6] = (Track[31] == null) ? EmptyCell : Track[31];
            Board[8, 6] = (Track[32] == null) ? EmptyCell : Track[32];
            Board[7, 6] = (Track[33] == null) ? EmptyCell : Track[33];
            Board[6, 6] = (Track[34] == null) ? EmptyCell : Track[34];

            Board[6, 7] = (Track[35] == null) ? EmptyCell : Track[35];
            Board[6, 8] = (Track[36] == null) ? EmptyCell : Track[36];
            Board[6, 9] = (Track[37] == null) ? EmptyCell : Track[37];
            Board[6, 10] = (Track[38] == null) ? EmptyCell : Track[38];

            Board[5, 10] = (Track[39] == null) ? EmptyCell : Track[39];

            for (int i = 0; i < 40; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                }
            }

            for (int i = 0; i < 11; i++)
            {
                for (int y = 0; y < 11; y++)
                {
                    if (Board[i, y] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"   ");
                    }
                    else
                    {
                        switch (Board[i, y].Color)
                        {
                            case null:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"[ ]");
                                break;

                            case (GameColor)0:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write($"[{Board[i, y].Number}]");
                                break;

                            case (GameColor)1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"[{Board[i, y].Number}]");
                                break;

                            case (GameColor)2:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"[{Board[i, y].Number}]");
                                break;

                            case (GameColor)3:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"[{Board[i, y].Number}]");
                                break;
                        }
                    }
                }
                Console.Write("\n");
            }
        }

        private string GetSymbol(int index)
        {
            return (Track[index] == null) ? " " : $"{Track[index].Number}";
        }
    }
}