using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Assets
{
    public class GameBoard
    {
        public GamePiece[] MainTrack { get; set; }
        public GamePiece[][] FinalTracks { get; set; }
        public GamePiece[,] BoardMap { get; set; }
        public GamePiece[] EmptyCells { get; set; }

        public GameBoard()
        {
            MainTrack = new GamePiece[40];
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

            //UppdateMapMainTrackCells();
            //UppdateMapFinalTracksCells();
        }

        public void UpdateTracks(List<GamePiece> gamePieceSetUp)
        {
            foreach (var piece in gamePieceSetUp)
            {
                var position = piece.TrackPosition;
                var color = piece.Color;
                if (position < 40)
                {
                    //add to track
                    var targetBoardTrackCellIndex = ((int)position + 10 * (int)color) % 40;
                    MainTrack[targetBoardTrackCellIndex] = piece;
                }
                else if (position >= 40 && position < 44)
                {
                    //add to final track
                    var targetFinalTrackCellIndex = (int)position - 40;
                    FinalTracks[(int)color][targetFinalTrackCellIndex] = piece;
                }
            }
        }

        public void UpdateMapCells(List<GamePiece> gamePeaceSetUp)
        {
            UppdateMapMainTrackCells();
            UppdateMapFinalTracksCells();
            UpdateBoardBases(gamePeaceSetUp);
        }

        public void UppdateMapMainTrackCells()
        {
            BoardMap[10, 4] = MainTrack[0] ?? EmptyCells[0];
            BoardMap[9, 4] = MainTrack[1] ?? EmptyCells[4];
            BoardMap[8, 4] = MainTrack[2] ?? EmptyCells[4];
            BoardMap[7, 4] = MainTrack[3] ?? EmptyCells[4];
            BoardMap[6, 4] = MainTrack[4] ?? EmptyCells[4];
            BoardMap[6, 3] = MainTrack[5] ?? EmptyCells[4];
            BoardMap[6, 2] = MainTrack[6] ?? EmptyCells[4];
            BoardMap[6, 1] = MainTrack[7] ?? EmptyCells[4];
            BoardMap[6, 0] = MainTrack[8] ?? EmptyCells[4];
            BoardMap[5, 0] = MainTrack[9] ?? EmptyCells[4];
            BoardMap[4, 0] = MainTrack[10] ?? EmptyCells[1];
            BoardMap[4, 1] = MainTrack[11] ?? EmptyCells[4];
            BoardMap[4, 2] = MainTrack[12] ?? EmptyCells[4];
            BoardMap[4, 3] = MainTrack[13] ?? EmptyCells[4];
            BoardMap[4, 4] = MainTrack[14] ?? EmptyCells[4];
            BoardMap[3, 4] = MainTrack[15] ?? EmptyCells[4];
            BoardMap[2, 4] = MainTrack[16] ?? EmptyCells[4];
            BoardMap[1, 4] = MainTrack[17] ?? EmptyCells[4];
            BoardMap[0, 4] = MainTrack[18] ?? EmptyCells[4];
            BoardMap[0, 5] = MainTrack[19] ?? EmptyCells[4];
            BoardMap[0, 6] = MainTrack[20] ?? EmptyCells[2];
            BoardMap[1, 6] = MainTrack[21] ?? EmptyCells[4];
            BoardMap[2, 6] = MainTrack[22] ?? EmptyCells[4];
            BoardMap[3, 6] = MainTrack[23] ?? EmptyCells[4];
            BoardMap[4, 6] = MainTrack[24] ?? EmptyCells[4];
            BoardMap[4, 7] = MainTrack[25] ?? EmptyCells[4];
            BoardMap[4, 8] = MainTrack[26] ?? EmptyCells[4];
            BoardMap[4, 9] = MainTrack[27] ?? EmptyCells[4];
            BoardMap[4, 10] = MainTrack[28] ?? EmptyCells[4];
            BoardMap[5, 10] = MainTrack[29] ?? EmptyCells[4];
            BoardMap[6, 10] = MainTrack[30] ?? EmptyCells[3];
            BoardMap[6, 9] = MainTrack[31] ?? EmptyCells[4];
            BoardMap[6, 8] = MainTrack[32] ?? EmptyCells[4];
            BoardMap[6, 7] = MainTrack[33] ?? EmptyCells[4];
            BoardMap[6, 6] = MainTrack[34] ?? EmptyCells[4];
            BoardMap[7, 6] = MainTrack[35] ?? EmptyCells[4];
            BoardMap[8, 6] = MainTrack[36] ?? EmptyCells[4];
            BoardMap[9, 6] = MainTrack[37] ?? EmptyCells[4];
            BoardMap[10, 6] = MainTrack[38] ?? EmptyCells[4];
            BoardMap[10, 5] = MainTrack[39] ?? EmptyCells[4];
        }

        public void UppdateMapFinalTracksCells()
        {
            for (int n = 0; n < 4; n++)
            {
                if (n == 0)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n][i] != null && FinalTracks[n][i].TrackPosition == 40 + i)
                            BoardMap[9 - i, 5] = FinalTracks[n][i];
                        else
                            BoardMap[9 - i, 5] = EmptyCells[n];
                if (n == 1)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n][i] != null && FinalTracks[n][i].TrackPosition == 40 + i)
                            BoardMap[5, 1 + i] = FinalTracks[n][i];
                        else
                            BoardMap[5, 1 + i] = EmptyCells[n];
                if (n == 2)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n][i] != null && FinalTracks[n][i].TrackPosition == 40 + i)
                            BoardMap[1 + i, 5] = FinalTracks[n][i];
                        else
                            BoardMap[1 + i, 5] = EmptyCells[n];
                if (n == 3)
                    for (int i = 0; i < 4; i++)
                        if (FinalTracks[n][i] != null && FinalTracks[n][i].TrackPosition == 40 + i)
                            BoardMap[5, 9 - i] = FinalTracks[n][i];
                        else
                            BoardMap[5, 9 - i] = EmptyCells[n];
            }
        }

        public void UpdateBoardBases(List<GamePiece> gamePieceSetUp)
        {
            foreach (var pieceGroup in gamePieceSetUp.GroupBy(p => p.Color).ToList())
            {
                var color = (int)pieceGroup.First().Color;
                var oneColorAtBasePieceSetup = gamePieceSetUp.Where(p => p.Color == (GameColor)color).ToList();
                int indexVer = 0;
                int indexHor = 0;
                if (color == 0) { indexVer = 8; indexHor = 1; }
                if (color == 1) { indexVer = 1; indexHor = 1; }
                if (color == 2) { indexVer = 1; indexHor = 8; }
                if (color == 3) { indexVer = 8; indexHor = 8; }
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

        public void PrintBoard(List<GamePiece> gamePieceSetUp)
        {
            UpdateMapCells(gamePieceSetUp);
            Console.WriteLine();
            for (int i = 0; i < 11; i++)
            {
                Console.Write($"   ");
                for (int y = 0; y < 11; y++)
                {
                    var color = BoardMap[i, y]?.Color;
                    Tools.SetConsoleColor(color);
                    RenderCell(i, y);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void RenderCell(int iIndex, int yIndex)
        {
            if (BoardMap[iIndex, yIndex] == null)
                Console.Write($"   ");
            else if (BoardMap[iIndex, yIndex].Number > 0)
                Console.Write($"[{BoardMap[iIndex, yIndex].Number}]");
            else
                Console.Write($"[ ]");
        }
    }
}