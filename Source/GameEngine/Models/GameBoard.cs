using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GameBoard
    {
        public GamePiece[] Track { get; set; }
        public GamePiece[][] FinalTracks { get; set; }

        public GameBoard()
        {
            Track = new GamePiece[40];
            FinalTracks = new GamePiece[4][];
            for (int i = 0; i < 4; i++)
            {
                FinalTracks[i] = new GamePiece[4];
            }
        }
    }
}