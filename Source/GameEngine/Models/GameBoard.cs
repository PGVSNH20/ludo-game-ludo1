using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Models
{
    public class GameBoard
    {
        public GamePiece[] Track { get; set; }
        public GamePiece[,] FinalTracks { get; set; }
        public GamePiece[,] Board { get; set; }
        public List<GamePiece> EmptyCells { get; set; }

        public GameBoard()
        {
            Track = new GamePiece[40];
            FinalTracks = new GamePiece[4, 4];

            Board = new GamePiece[11, 11];
            EmptyCells = new List<GamePiece>(){
                new GamePiece() { Number = 0, Color = (GameColor)0 },
                new GamePiece() { Number = 0, Color = (GameColor)1 },
                new GamePiece() { Number = 0, Color = (GameColor)2 },
                new GamePiece() { Number = 0, Color = (GameColor)3 },
                new GamePiece() { Number = 0, Color = null },
            };

            for (int i = 0; i < 11; i++)
            {
                for (int y = 0; y < 11; y++)
                {
                    Board[i, y] = null;
                }
            }
        }

        public void PrintBoard(List<GamePiece> gamePeaceSetUp)
        {
            //track
            Board[10, 4] = (Track[0] == null) ? EmptyCells[4] : Track[0];
            Board[9, 4] = (Track[1] == null) ? EmptyCells[4] : Track[1];
            Board[8, 4] = (Track[2] == null) ? EmptyCells[4] : Track[2];
            Board[7, 4] = (Track[3] == null) ? EmptyCells[4] : Track[3];
            Board[6, 4] = (Track[4] == null) ? EmptyCells[4] : Track[4];
            Board[6, 3] = (Track[5] == null) ? EmptyCells[4] : Track[5];
            Board[6, 2] = (Track[6] == null) ? EmptyCells[4] : Track[6];
            Board[6, 1] = (Track[7] == null) ? EmptyCells[4] : Track[7];
            Board[6, 0] = (Track[8] == null) ? EmptyCells[4] : Track[8];
            Board[5, 0] = (Track[9] == null) ? EmptyCells[4] : Track[9];
            Board[4, 0] = (Track[10] == null) ? EmptyCells[4] : Track[10];
            Board[4, 1] = (Track[11] == null) ? EmptyCells[4] : Track[11];
            Board[4, 2] = (Track[12] == null) ? EmptyCells[4] : Track[12];
            Board[4, 3] = (Track[13] == null) ? EmptyCells[4] : Track[13];
            Board[4, 4] = (Track[14] == null) ? EmptyCells[4] : Track[14];
            Board[3, 4] = (Track[15] == null) ? EmptyCells[4] : Track[15];
            Board[2, 4] = (Track[16] == null) ? EmptyCells[4] : Track[16];
            Board[1, 4] = (Track[17] == null) ? EmptyCells[4] : Track[17];
            Board[0, 4] = (Track[18] == null) ? EmptyCells[4] : Track[18];
            Board[0, 5] = (Track[19] == null) ? EmptyCells[4] : Track[19];
            Board[0, 6] = (Track[20] == null) ? EmptyCells[4] : Track[20];
            Board[1, 6] = (Track[21] == null) ? EmptyCells[4] : Track[21];
            Board[2, 6] = (Track[22] == null) ? EmptyCells[4] : Track[22];
            Board[3, 6] = (Track[23] == null) ? EmptyCells[4] : Track[23];
            Board[4, 6] = (Track[24] == null) ? EmptyCells[4] : Track[24];
            Board[4, 7] = (Track[25] == null) ? EmptyCells[4] : Track[25];
            Board[4, 8] = (Track[26] == null) ? EmptyCells[4] : Track[26];
            Board[4, 9] = (Track[27] == null) ? EmptyCells[4] : Track[27];
            Board[4, 10] = (Track[28] == null) ? EmptyCells[4] : Track[28];
            Board[5, 10] = (Track[29] == null) ? EmptyCells[4] : Track[29];
            Board[6, 10] = (Track[30] == null) ? EmptyCells[4] : Track[30];
            Board[6, 9] = (Track[31] == null) ? EmptyCells[4] : Track[31];
            Board[6, 8] = (Track[32] == null) ? EmptyCells[4] : Track[32];
            Board[6, 7] = (Track[33] == null) ? EmptyCells[4] : Track[33];
            Board[6, 6] = (Track[34] == null) ? EmptyCells[4] : Track[34];
            Board[7, 6] = (Track[35] == null) ? EmptyCells[4] : Track[35];
            Board[8, 6] = (Track[36] == null) ? EmptyCells[4] : Track[36];
            Board[9, 6] = (Track[37] == null) ? EmptyCells[4] : Track[37];
            Board[10, 6] = (Track[38] == null) ? EmptyCells[4] : Track[38];
            Board[10, 5] = (Track[39] == null) ? EmptyCells[4] : Track[39];

            //base
            for (int n = 0; n < 4; n++)
            {
                var oneColorAtBasePieceSetup = gamePeaceSetUp.Where(p => p.Color == (GameColor)n).ToList();
                int indexVer = 0;
                int indexHor = 0;
                if (n == 0)
                {
                    indexVer = 8;
                    indexHor = 1;
                }
                if (n == 1)
                {
                    indexVer = 1;
                    indexHor = 1;
                }
                if (n == 2)
                {
                    indexVer = 1;
                    indexHor = 8;
                }
                if (n == 3)
                {
                    indexVer = 8;
                    indexHor = 8;
                }
                for (int i = 0; i < 4; i++)
                {
                    var additionalHor = i % 2;
                    var additionalVer = i / 2;
                    if (oneColorAtBasePieceSetup[i].Possition == null)
                        Board[(indexVer + additionalVer), (indexHor + additionalHor)] = oneColorAtBasePieceSetup.Where(p => p.Number == (i + 1)).Single();
                    else
                        Board[(indexVer + additionalVer), (indexHor + additionalHor)] = EmptyCells[n];
                }
            }
            //final tracks
            for (int n = 0; n < 4; n++)
            {
                if (n == 0)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n, i] != null && FinalTracks[n, i].Possition == 40 + i)
                            Board[9 - i, 5] = FinalTracks[n, i];
                        else
                            Board[9 - i, 5] = EmptyCells[n];
                if (n == 1)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n, i] != null && FinalTracks[n, i].Possition == 40 + i)
                            Board[5, 1 + i] = FinalTracks[n, i];
                        else
                            Board[5, 1 + i] = EmptyCells[n];
                if (n == 2)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n, i] != null && FinalTracks[n, i].Possition == 40 + i)
                            Board[1 + i, 5] = FinalTracks[n, i];
                        else
                            Board[1 + i, 5] = EmptyCells[n];
                if (n == 3)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n, i] != null && FinalTracks[n, i].Possition == 40 + i)
                            Board[5, 9 - i] = FinalTracks[n, i];
                        else
                            Board[5, 9 - i] = EmptyCells[n];
            }

            Console.WriteLine();
            for (int i = 0; i < 11; i++)
            {
                Console.Write($"   ");
                for (int y = 0; y < 11; y++)
                {
                    if (Board[i, y] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
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
                                RenderCell(i, y);
                                break;

                            case (GameColor)1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                RenderCell(i, y);
                                break;

                            case (GameColor)2:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                RenderCell(i, y);
                                break;

                            case (GameColor)3:
                                Console.ForegroundColor = ConsoleColor.Green;
                                RenderCell(i, y);
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

        private void RenderCell(int iIndex, int yIndex)
        {
            if (Board[iIndex, yIndex].Number > 0)
                Console.Write($"[{Board[iIndex, yIndex].Number}]");
            else
                Console.Write($"[ ]");
        }
    }
}