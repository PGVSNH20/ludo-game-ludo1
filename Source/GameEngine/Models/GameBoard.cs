using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Models
{
    public class GameBoard
    {
        public List<GamePiece>[] Track { get; set; }
        public List<GamePiece>[,] FinalTracks { get; set; }
        public List<GamePiece>[,] BoardMap { get; set; }
        public List<GamePiece>[] EmptyCells { get; set; }

        public GameBoard()
        {
            Track = new List<GamePiece>[40];
            FinalTracks = new List<GamePiece>[4, 4];

            BoardMap = new List<GamePiece>[11, 11];
            EmptyCells = new List<GamePiece>[5]{
                new List<GamePiece>() { new GamePiece() { Number = 0, Color = (GameColor)0 } },
                new List<GamePiece>() { new GamePiece() { Number = 0, Color = (GameColor)1 }},
                new List<GamePiece>() { new GamePiece() { Number = 0, Color = (GameColor)2 }},
                new List<GamePiece>() { new GamePiece() { Number = 0, Color = (GameColor)3 }},
                new List<GamePiece>() { new GamePiece() { Number = 0, Color = null }}
            };

            for (int i = 0; i < 11; i++)
            {
                for (int y = 0; y < 11; y++)
                {
                    BoardMap[i, y] = null;
                }
            }

            UppdateBoardTrackCells();
        }

        public void UppdateBoardTrackCells()
        {
            //track
            BoardMap[10, 4] = (Track[0] == null || Track[0].Count == 0) ? EmptyCells[4] : Track[0];
            BoardMap[9, 4] = (Track[1] == null || Track[1].Count == 0) ? EmptyCells[4] : Track[1];
            BoardMap[8, 4] = (Track[2] == null || Track[2].Count == 0) ? EmptyCells[4] : Track[2];
            BoardMap[7, 4] = (Track[3] == null || Track[3].Count == 0) ? EmptyCells[4] : Track[3];
            BoardMap[6, 4] = (Track[4] == null || Track[4].Count == 0) ? EmptyCells[4] : Track[4];
            BoardMap[6, 3] = (Track[5] == null || Track[5].Count == 0) ? EmptyCells[4] : Track[5];
            BoardMap[6, 2] = (Track[6] == null || Track[6].Count == 0) ? EmptyCells[4] : Track[6];
            BoardMap[6, 1] = (Track[7] == null || Track[7].Count == 0) ? EmptyCells[4] : Track[7];
            BoardMap[6, 0] = (Track[8] == null || Track[8].Count == 0) ? EmptyCells[4] : Track[8];
            BoardMap[5, 0] = (Track[9] == null || Track[9].Count == 0) ? EmptyCells[4] : Track[9];
            BoardMap[4, 0] = (Track[10] == null || Track[10].Count == 0) ? EmptyCells[4] : Track[10];
            BoardMap[4, 1] = (Track[11] == null || Track[11].Count == 0) ? EmptyCells[4] : Track[11];
            BoardMap[4, 2] = (Track[12] == null || Track[12].Count == 0) ? EmptyCells[4] : Track[12];
            BoardMap[4, 3] = (Track[13] == null || Track[13].Count == 0) ? EmptyCells[4] : Track[13];
            BoardMap[4, 4] = (Track[14] == null || Track[14].Count == 0) ? EmptyCells[4] : Track[14];
            BoardMap[3, 4] = (Track[15] == null || Track[15].Count == 0) ? EmptyCells[4] : Track[15];
            BoardMap[2, 4] = (Track[16] == null || Track[16].Count == 0) ? EmptyCells[4] : Track[16];
            BoardMap[1, 4] = (Track[17] == null || Track[17].Count == 0) ? EmptyCells[4] : Track[17];
            BoardMap[0, 4] = (Track[18] == null || Track[18].Count == 0) ? EmptyCells[4] : Track[18];
            BoardMap[0, 5] = (Track[19] == null || Track[19].Count == 0) ? EmptyCells[4] : Track[19];
            BoardMap[0, 6] = (Track[20] == null || Track[20].Count == 0) ? EmptyCells[4] : Track[20];
            BoardMap[1, 6] = (Track[21] == null || Track[21].Count == 0) ? EmptyCells[4] : Track[21];
            BoardMap[2, 6] = (Track[22] == null || Track[22].Count == 0) ? EmptyCells[4] : Track[22];
            BoardMap[3, 6] = (Track[23] == null || Track[23].Count == 0) ? EmptyCells[4] : Track[23];
            BoardMap[4, 6] = (Track[24] == null || Track[24].Count == 0) ? EmptyCells[4] : Track[24];
            BoardMap[4, 7] = (Track[25] == null || Track[25].Count == 0) ? EmptyCells[4] : Track[25];
            BoardMap[4, 8] = (Track[26] == null || Track[26].Count == 0) ? EmptyCells[4] : Track[26];
            BoardMap[4, 9] = (Track[27] == null || Track[27].Count == 0) ? EmptyCells[4] : Track[27];
            BoardMap[4, 10] = (Track[28] == null || Track[28].Count == 0) ? EmptyCells[4] : Track[28];
            BoardMap[5, 10] = (Track[29] == null || Track[29].Count == 0) ? EmptyCells[4] : Track[29];
            BoardMap[6, 10] = (Track[30] == null || Track[30].Count == 0) ? EmptyCells[4] : Track[30];
            BoardMap[6, 9] = (Track[31] == null || Track[31].Count == 0) ? EmptyCells[4] : Track[31];
            BoardMap[6, 8] = (Track[32] == null || Track[32].Count == 0) ? EmptyCells[4] : Track[32];
            BoardMap[6, 7] = (Track[33] == null || Track[33].Count == 0) ? EmptyCells[4] : Track[33];
            BoardMap[6, 6] = (Track[34] == null || Track[34].Count == 0) ? EmptyCells[4] : Track[34];
            BoardMap[7, 6] = (Track[35] == null || Track[35].Count == 0) ? EmptyCells[4] : Track[35];
            BoardMap[8, 6] = (Track[36] == null || Track[36].Count == 0) ? EmptyCells[4] : Track[36];
            BoardMap[9, 6] = (Track[37] == null || Track[37].Count == 0) ? EmptyCells[4] : Track[37];
            BoardMap[10, 6] = (Track[38] == null || Track[38].Count == 0) ? EmptyCells[4] : Track[38];
            BoardMap[10, 5] = (Track[39] == null || Track[39].Count == 0) ? EmptyCells[4] : Track[39];

            //final tracks
        }

        public void UppdateFinalTracksCells()
        {
            //Board[9, 5] = (FinalTracks[0, 0] == null || FinalTracks[0, 0].Count == 0) ? EmptyCells[0] : FinalTracks[0, 0];
            //Board[8, 5] = (FinalTracks[0, 1] == null || FinalTracks[0, 1].Count == 0) ? EmptyCells[0] : FinalTracks[0, 1];
            //Board[7, 5] = (FinalTracks[0, 2] == null || FinalTracks[0, 2].Count == 0) ? EmptyCells[0] : FinalTracks[0, 2];
            //Board[6, 5] = (FinalTracks[0, 3] == null || FinalTracks[0, 3].Count == 0) ? EmptyCells[0] : FinalTracks[0, 3];

            //Board[5, 1] = (FinalTracks[1, 0] == null || FinalTracks[1, 0].Count == 0) ? EmptyCells[1] : FinalTracks[1, 0];
            //Board[5, 2] = (FinalTracks[1, 1] == null || FinalTracks[1, 1].Count == 0) ? EmptyCells[1] : FinalTracks[1, 1];
            //Board[5, 3] = (FinalTracks[1, 2] == null || FinalTracks[1, 2].Count == 0) ? EmptyCells[1] : FinalTracks[1, 2];
            //Board[5, 4] = (FinalTracks[1, 3] == null || FinalTracks[1, 3].Count == 0) ? EmptyCells[1] : FinalTracks[1, 3];

            //Board[1, 5] = (FinalTracks[2, 0] == null || FinalTracks[2, 0].Count == 0) ? EmptyCells[2] : FinalTracks[2, 0];
            //Board[2, 5] = (FinalTracks[2, 1] == null || FinalTracks[2, 1].Count == 0) ? EmptyCells[2] : FinalTracks[2, 1];
            //Board[3, 5] = (FinalTracks[2, 2] == null || FinalTracks[2, 2].Count == 0) ? EmptyCells[2] : FinalTracks[2, 2];
            //Board[4, 5] = (FinalTracks[2, 3] == null || FinalTracks[2, 3].Count == 0) ? EmptyCells[2] : FinalTracks[2, 3];

            //Board[5, 9] = (FinalTracks[3, 0] == null || FinalTracks[3, 0].Count == 0) ? EmptyCells[3] : FinalTracks[3, 0];
            //Board[5, 8] = (FinalTracks[3, 1] == null || FinalTracks[3, 1].Count == 0) ? EmptyCells[3] : FinalTracks[3, 1];
            //Board[5, 7] = (FinalTracks[3, 2] == null || FinalTracks[3, 2].Count == 0) ? EmptyCells[3] : FinalTracks[3, 2];
            //Board[5, 6] = (FinalTracks[3, 3] == null || FinalTracks[3, 3].Count == 0) ? EmptyCells[3] : FinalTracks[3, 3];

            for (int n = 0; n < 4; n++)
            {
                if (n == 0)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n, i] != null && FinalTracks[n, i][0].Possition == 40 + i)
                            BoardMap[9 - i, 5] = FinalTracks[n, i];
                        else
                            BoardMap[9 - i, 5] = EmptyCells[n];
                if (n == 1)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n, i] != null && FinalTracks[n, i][0].Possition == 40 + i)
                            BoardMap[5, 1 + i] = FinalTracks[n, i];
                        else
                            BoardMap[5, 1 + i] = EmptyCells[n];
                if (n == 2)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n, i] != null && FinalTracks[n, i][0].Possition == 40 + i)
                            BoardMap[1 + i, 5] = FinalTracks[n, i];
                        else
                            BoardMap[1 + i, 5] = EmptyCells[n];
                if (n == 3)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n, i] != null && FinalTracks[n, i][0].Possition == 40 + i)
                            BoardMap[5, 9 - i] = FinalTracks[n, i];
                        else
                            BoardMap[5, 9 - i] = EmptyCells[n];
            }
        }

        public void UpdateBoardBasesCells(List<GamePiece> gamePeaceSetUp)
        {
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
                    if (BoardMap[(indexVer + additionalVer), (indexHor + additionalHor)] == null)
                        BoardMap[(indexVer + additionalVer), (indexHor + additionalHor)] = new List<GamePiece>();
                    if (oneColorAtBasePieceSetup[i].Possition == null || oneColorAtBasePieceSetup[i].Possition == -1)
                    {
                        BoardMap[(indexVer + additionalVer), (indexHor + additionalHor)].Clear();
                        BoardMap[(indexVer + additionalVer), (indexHor + additionalHor)].Add(oneColorAtBasePieceSetup.Where(p => p.Number == (i + 1)).Single());
                    }
                    else
                    {
                        BoardMap[(indexVer + additionalVer), (indexHor + additionalHor)].Clear();
                        BoardMap[(indexVer + additionalVer), (indexHor + additionalHor)].Add(EmptyCells[n][0]);
                    }
                }
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < 11; i++)
            {
                Console.Write($"   ");
                for (int y = 0; y < 11; y++)
                {
                    if (BoardMap[i, y] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"   ");
                    }
                    else
                    {
                        switch (BoardMap[i, y][0].Color)
                        {
                            case null:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"[ ]");
                                break;

                            case (GameColor)0:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                RenderCell(i, y);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case (GameColor)1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                RenderCell(i, y);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case (GameColor)2:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                RenderCell(i, y);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case (GameColor)3:
                                Console.ForegroundColor = ConsoleColor.Green;
                                RenderCell(i, y);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                    }
                }
                Console.Write("\n");
            }
        }

        private void RenderCell(int iIndex, int yIndex)
        {
            if (BoardMap[iIndex, yIndex].Count > 1)
                Console.Write($"[*]");
            else if (BoardMap[iIndex, yIndex][0].Number > 0)
                Console.Write($"[{BoardMap[iIndex, yIndex][0].Number}]");
            else
                Console.Write($"[ ]");
        }
    }
}