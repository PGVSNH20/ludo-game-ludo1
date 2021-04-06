using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Models
{
    public class GameBoard
    {
        public GamePiece[] Track { get; set; }
        public GamePiece[][] FinalTracks { get; set; }
        public GamePiece[,] BoardMap { get; set; }
        public GamePiece[] EmptyCells { get; set; }
        private StringBuilder BoardAsString;

        public GameBoard()
        {
            Track = new GamePiece[40];
            FinalTracks = new GamePiece[4][];
            BoardMap = new GamePiece[11, 11];
            EmptyCells = new GamePiece[5]{
                new GamePiece() { Number = 0, Color = (GameColor)0 },
                new GamePiece() { Number = 0, Color = (GameColor)1 },
                new GamePiece() { Number = 0, Color = (GameColor)2 },
                new GamePiece() { Number = 0, Color = (GameColor)3 },
                new GamePiece() { Number = 0, Color = null }
            };
            for (int i = 0; i < 4; i++)
            {
                FinalTracks[i] = new GamePiece[4];
            }

            UppdateBoardTrackCells();
            UppdateFinalTracksCells();
        }

        public void UpdateBoardCells(List<GamePiece> gamePeaceSetUp)
        {
            UppdateBoardTrackCells();
            UppdateFinalTracksCells();
            UpdateBoardBasesCells(gamePeaceSetUp);
        }

        private void UppdateBoardTrackCells()
        {
            //track
            BoardMap[10, 4] = (Track[0] == null) ? EmptyCells[4] : Track[0];
            BoardMap[9, 4] = (Track[1] == null) ? EmptyCells[4] : Track[1];
            BoardMap[8, 4] = (Track[2] == null) ? EmptyCells[4] : Track[2];
            BoardMap[7, 4] = (Track[3] == null) ? EmptyCells[4] : Track[3];
            BoardMap[6, 4] = (Track[4] == null) ? EmptyCells[4] : Track[4];
            BoardMap[6, 3] = (Track[5] == null) ? EmptyCells[4] : Track[5];
            BoardMap[6, 2] = (Track[6] == null) ? EmptyCells[4] : Track[6];
            BoardMap[6, 1] = (Track[7] == null) ? EmptyCells[4] : Track[7];
            BoardMap[6, 0] = (Track[8] == null) ? EmptyCells[4] : Track[8];
            BoardMap[5, 0] = (Track[9] == null) ? EmptyCells[4] : Track[9];
            BoardMap[4, 0] = (Track[10] == null) ? EmptyCells[4] : Track[10];
            BoardMap[4, 1] = (Track[11] == null) ? EmptyCells[4] : Track[11];
            BoardMap[4, 2] = (Track[12] == null) ? EmptyCells[4] : Track[12];
            BoardMap[4, 3] = (Track[13] == null) ? EmptyCells[4] : Track[13];
            BoardMap[4, 4] = (Track[14] == null) ? EmptyCells[4] : Track[14];
            BoardMap[3, 4] = (Track[15] == null) ? EmptyCells[4] : Track[15];
            BoardMap[2, 4] = (Track[16] == null) ? EmptyCells[4] : Track[16];
            BoardMap[1, 4] = (Track[17] == null) ? EmptyCells[4] : Track[17];
            BoardMap[0, 4] = (Track[18] == null) ? EmptyCells[4] : Track[18];
            BoardMap[0, 5] = (Track[19] == null) ? EmptyCells[4] : Track[19];
            BoardMap[0, 6] = (Track[20] == null) ? EmptyCells[4] : Track[20];
            BoardMap[1, 6] = (Track[21] == null) ? EmptyCells[4] : Track[21];
            BoardMap[2, 6] = (Track[22] == null) ? EmptyCells[4] : Track[22];
            BoardMap[3, 6] = (Track[23] == null) ? EmptyCells[4] : Track[23];
            BoardMap[4, 6] = (Track[24] == null) ? EmptyCells[4] : Track[24];
            BoardMap[4, 7] = (Track[25] == null) ? EmptyCells[4] : Track[25];
            BoardMap[4, 8] = (Track[26] == null) ? EmptyCells[4] : Track[26];
            BoardMap[4, 9] = (Track[27] == null) ? EmptyCells[4] : Track[27];
            BoardMap[4, 10] = (Track[28] == null) ? EmptyCells[4] : Track[28];
            BoardMap[5, 10] = (Track[29] == null) ? EmptyCells[4] : Track[29];
            BoardMap[6, 10] = (Track[30] == null) ? EmptyCells[4] : Track[30];
            BoardMap[6, 9] = (Track[31] == null) ? EmptyCells[4] : Track[31];
            BoardMap[6, 8] = (Track[32] == null) ? EmptyCells[4] : Track[32];
            BoardMap[6, 7] = (Track[33] == null) ? EmptyCells[4] : Track[33];
            BoardMap[6, 6] = (Track[34] == null) ? EmptyCells[4] : Track[34];
            BoardMap[7, 6] = (Track[35] == null) ? EmptyCells[4] : Track[35];
            BoardMap[8, 6] = (Track[36] == null) ? EmptyCells[4] : Track[36];
            BoardMap[9, 6] = (Track[37] == null) ? EmptyCells[4] : Track[37];
            BoardMap[10, 6] = (Track[38] == null) ? EmptyCells[4] : Track[38];
            BoardMap[10, 5] = (Track[39] == null) ? EmptyCells[4] : Track[39];
        }

        private void UppdateFinalTracksCells()
        {
            BoardMap[9, 5] = (FinalTracks[0][0] == null) ? EmptyCells[0] : FinalTracks[0][0];
            BoardMap[8, 5] = (FinalTracks[0][1] == null) ? EmptyCells[0] : FinalTracks[0][1];
            BoardMap[7, 5] = (FinalTracks[0][2] == null) ? EmptyCells[0] : FinalTracks[0][2];
            BoardMap[6, 5] = (FinalTracks[0][3] == null) ? EmptyCells[0] : FinalTracks[0][3];
            BoardMap[5, 1] = (FinalTracks[1][0] == null) ? EmptyCells[1] : FinalTracks[1][0];
            BoardMap[5, 2] = (FinalTracks[1][1] == null) ? EmptyCells[1] : FinalTracks[1][1];
            BoardMap[5, 3] = (FinalTracks[1][2] == null) ? EmptyCells[1] : FinalTracks[1][2];
            BoardMap[5, 4] = (FinalTracks[1][3] == null) ? EmptyCells[1] : FinalTracks[1][3];
            BoardMap[1, 5] = (FinalTracks[2][0] == null) ? EmptyCells[2] : FinalTracks[2][0];
            BoardMap[2, 5] = (FinalTracks[2][1] == null) ? EmptyCells[2] : FinalTracks[2][1];
            BoardMap[3, 5] = (FinalTracks[2][2] == null) ? EmptyCells[2] : FinalTracks[2][2];
            BoardMap[4, 5] = (FinalTracks[2][3] == null) ? EmptyCells[2] : FinalTracks[2][3];
            BoardMap[5, 9] = (FinalTracks[3][0] == null) ? EmptyCells[3] : FinalTracks[3][0];
            BoardMap[5, 8] = (FinalTracks[3][1] == null) ? EmptyCells[3] : FinalTracks[3][1];
            BoardMap[5, 7] = (FinalTracks[3][2] == null) ? EmptyCells[3] : FinalTracks[3][2];
            BoardMap[5, 6] = (FinalTracks[3][3] == null) ? EmptyCells[3] : FinalTracks[3][3];

            //for (int n = 0; n < 4; n++)
            //{
            //    if (n == 0)
            //        for (int i = 0; i < 4; i++)
            //            if (FinalTracks[n][i] != null && FinalTracks[n][i].TrackPosition == 40 + i)
            //                BoardMap[9 - i, 5] = FinalTracks[n][i];
            //            else
            //                BoardMap[9 - i, 5] = EmptyCells[n];
            //    if (n == 1)
            //        for (int i = 0; i < 4; i++)
            //            if (FinalTracks[n][i] != null && FinalTracks[n][i].TrackPosition == 40 + i)
            //                BoardMap[5, 1 + i] = FinalTracks[n][i];
            //            else
            //                BoardMap[5, 1 + i] = EmptyCells[n];
            //    if (n == 2)
            //        for (int i = 0; i < 4; i++)
            //            if (FinalTracks[n][i] != null && FinalTracks[n][i].TrackPosition == 40 + i)
            //                BoardMap[1 + i, 5] = FinalTracks[n][i];
            //            else
            //                BoardMap[1 + i, 5] = EmptyCells[n];
            //    if (n == 3)
            //        for (int i = 0; i < 4; i++)
            //            if (FinalTracks[n][i] != null && FinalTracks[n][i].TrackPosition == 40 + i)
            //                BoardMap[5, 9 - i] = FinalTracks[n][i];
            //            else
            //                BoardMap[5, 9 - i] = EmptyCells[n];
            //}
        }

        private void UpdateBoardBasesCells(List<GamePiece> gamePeaceSetUp)
        {
            //BoardMap[8, 1] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)0 && p.Number == 1).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)0 && p.Number == 1).Single() : EmptyCells[0];
            //BoardMap[8, 2] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)0 && p.Number == 2).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)0 && p.Number == 2).Single() : EmptyCells[0];
            //BoardMap[9, 1] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)0 && p.Number == 3).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)0 && p.Number == 3).Single() : EmptyCells[0];
            //BoardMap[9, 2] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)0 && p.Number == 4).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)0 && p.Number == 4).Single() : EmptyCells[0];
            //BoardMap[1, 1] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)1 && p.Number == 1).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)1 && p.Number == 1).Single() : EmptyCells[1];
            //BoardMap[1, 2] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)1 && p.Number == 2).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)1 && p.Number == 2).Single() : EmptyCells[1];
            //BoardMap[2, 1] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)1 && p.Number == 3).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)1 && p.Number == 3).Single() : EmptyCells[1];
            //BoardMap[2, 2] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)1 && p.Number == 4).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)1 && p.Number == 4).Single() : EmptyCells[1];
            //BoardMap[1, 8] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)2 && p.Number == 1).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)2 && p.Number == 1).Single() : EmptyCells[2];
            //BoardMap[1, 9] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)2 && p.Number == 2).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)2 && p.Number == 2).Single() : EmptyCells[2];
            //BoardMap[2, 8] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)2 && p.Number == 3).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)2 && p.Number == 3).Single() : EmptyCells[2];
            //BoardMap[2, 9] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)2 && p.Number == 4).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)2 && p.Number == 4).Single() : EmptyCells[2];
            //BoardMap[8, 8] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)3 && p.Number == 1).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)3 && p.Number == 1).Single() : EmptyCells[3];
            //BoardMap[8, 9] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)3 && p.Number == 2).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)3 && p.Number == 2).Single() : EmptyCells[3];
            //BoardMap[9, 8] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)3 && p.Number == 3).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)3 && p.Number == 3).Single() : EmptyCells[3];
            //BoardMap[9, 9] = (gamePeaceSetUp.Where(p => p.Color == (GameColor)3 && p.Number == 4).Single().TrackPosition == null) ? gamePeaceSetUp.Where(p => p.Color == (GameColor)3 && p.Number == 4).Single() : EmptyCells[3];
            //base
            //for (int n = 0; n < gamePeaceSetUp.GroupBy(p => p.Color).Count(); n++)
            foreach (var piece in gamePeaceSetUp.GroupBy(p => p.Color).ToList()[0])
            {
                var color = (int)piece.Color;
                var oneColorAtBasePieceSetup = gamePeaceSetUp.Where(p => p.Color == (GameColor)color).ToList();
                int indexVer = 0;
                int indexHor = 0;
                if (color == 0)
                {
                    indexVer = 8;
                    indexHor = 1;
                }
                if (color == 1)
                {
                    indexVer = 1;
                    indexHor = 1;
                }
                if (color == 2)
                {
                    indexVer = 1;
                    indexHor = 8;
                }
                if (color == 3)
                {
                    indexVer = 8;
                    indexHor = 8;
                }
                for (int i = 0; i < 4; i++)
                {
                    var additionalHor = i % 2;
                    var additionalVer = i / 2;

                    if (oneColorAtBasePieceSetup[i].TrackPosition == null)
                        BoardMap[(indexVer + additionalVer), (indexHor + additionalHor)] = oneColorAtBasePieceSetup.Where(p => p.Number == (i + 1)).Single();
                    else
                        BoardMap[(indexVer + additionalVer), (indexHor + additionalHor)] = EmptyCells[color];
                }
            }
        }

        public string PrintBoard()
        {
            Console.Clear();
            BoardAsString = new StringBuilder();
            Console.WriteLine();
            BoardAsString.Append("\n");
            for (int i = 0; i < 11; i++)
            {
                Console.Write($"   ");
                BoardAsString.Append($"   ");
                for (int y = 0; y < 11; y++)
                {
                    if (BoardMap[i, y] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"   ");
                        BoardAsString.Append($"   ");
                    }
                    else
                    {
                        switch (BoardMap[i, y].Color)
                        {
                            case null:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"[ ]");
                                BoardAsString.Append($"[ ]");
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
                BoardAsString.Append("\n");
            }
            return BoardAsString.ToString();
        }

        private void RenderCell(int iIndex, int yIndex)
        {
            if (BoardMap[iIndex, yIndex].Number > 0)
            {
                Console.Write($"[{BoardMap[iIndex, yIndex].Number}]");
                BoardAsString.Append($"[{BoardMap[iIndex, yIndex].Number}]");
            }
            else
            {
                Console.Write($"[ ]");
                BoardAsString.Append($"[ ]");
            }
        }
    }
}