﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GamePiece
    {
        public GameColour Colour { get; set; }
        public int Number { get; set; }
        public int TrackPosition { get; set; }


        public List<GamePiece> GetGamePieceSetup()
        {
            var gamePieceSetup = new List<GamePiece>();
            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < 4; y++)
                {
                    var gamePiece = new GamePiece()
                    {
                        Colour = (GameColour)i,
                        Number = y
                    };
                    gamePieceSetup.Add(gamePiece);
                }
            }
            return gamePieceSetup;
        } 
    }
        public enum GameColour
        {
            Red, Blue, Green, Yellow
        }
}
