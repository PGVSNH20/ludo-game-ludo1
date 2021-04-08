using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Assets
{
    public class Tools
    {
        public static List<GamePiece> GetGamePieceSetup(List<GamePlayer> gamePlayers)
        {
            var gamePieceSetup = new List<GamePiece>();
            foreach (var player in gamePlayers)
            {
                for (int i = 0; i < 4; i++)
                {
                    var gamePiece = new GamePiece()
                    {
                        Color = player.Color,
                        Number = i + 1
                    };
                    gamePieceSetup.Add(gamePiece);
                }
            }
            return gamePieceSetup;
        }

        public static List<GamePiece> GetMovableGamePieces(List<GamePiece> gamePieceSetup, GameColor color, int diceResult)
        {
            //List of Pieces of same color
            var playerPieces = gamePieceSetup.Where(p => p.Color == color).ToList();
            var movablePieces = new List<GamePiece>();
            if (diceResult != 1 && diceResult != 6)
            {
                //List of Pieces of same color that are not att null (base)
                playerPieces = playerPieces.Where(p => p.TrackPosition != null).ToList();
            }

            if (playerPieces.Count > 0)
            {
                for (int i = 0; i < playerPieces.Count(); i++)
                {
                    //Iteration through available pieces to see if specific piece can be moved to target position
                    //piece can not be places att position which already contains piece of same color
                    //piece can not jump over another piece of same color

                    // TODO: Piece can jump over itself in finalTrack
                    var originalPosition = playerPieces[i].TrackPosition;
                    var positionAhead = (originalPosition == null) ? -1 : originalPosition;
                    var potencialTrackPosition = CalculateNewPositon(originalPosition, diceResult);
                    while (positionAhead <= potencialTrackPosition)
                    {
                        positionAhead++;
                        if (playerPieces.FindAll(p => p.TrackPosition == positionAhead).Count > 0)
                            break;

                        if (playerPieces.FindAll(p => p.TrackPosition == potencialTrackPosition).Count == 0 && positionAhead == potencialTrackPosition)
                            movablePieces.Add(playerPieces[i]);
                    }
                }
            }

            return movablePieces;
        }

        public static int CalculateNewPositon(int? originalPosition, int diceValue)

        {
            var newPosition = (originalPosition == null) ? diceValue - 1 : (int)originalPosition + diceValue;
            newPosition = (newPosition > 44) ? 88 - newPosition : newPosition;
            return newPosition;
        }

        public static void SetConsoleColor(GameColor gameColor)
        {
            if (gameColor == 0) Console.ForegroundColor = ConsoleColor.Blue;
            else if (gameColor == (GameColor)1) Console.ForegroundColor = ConsoleColor.Red;
            else if (gameColor == (GameColor)2) Console.ForegroundColor = ConsoleColor.Yellow;
            else if (gameColor == (GameColor)3) Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}