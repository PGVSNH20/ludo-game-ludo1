using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GamePiece
    {
        public GameColor? Color { get; set; }
        public int Number { get; set; }
        public int? TrackPosition { get; set; }

        public static List<GamePiece> GetGamePieceSetup(List<GamePlayer> gamePlayers)
        {
            var gamePieceSetup = new List<GamePiece>();
            foreach (var player in gamePlayers)
            {
                for (int i = 0; i < 4; i++)
                {
                    var gamePiece = new GamePiece()
                    {
                        Color = player.GamePlayerColour,
                        Number = i + 1
                    };
                    gamePieceSetup.Add(gamePiece);
                }
            }
            return gamePieceSetup;
        }
    }

    public enum GameColor
    {
        Blue, Red, Yellow, Green
    }
}