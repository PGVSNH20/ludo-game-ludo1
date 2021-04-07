using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Tools
    {
        public static int GetPlayerAmount()
        {
            int playerAmmount = 0;
            while (playerAmmount < 2 || playerAmmount > 4)
            {
                Console.WriteLine("Choose how many players: ");
                try
                {
                    playerAmmount = Convert.ToInt32(Console.ReadLine().Trim());
                    if (playerAmmount >= 2 && playerAmmount <= 4)
                        Console.WriteLine($"{playerAmmount} players will play!");
                    else
                        Console.WriteLine("Choose between 2 and 4");
                }
                catch { Console.WriteLine("Input not accepted. Choose between 2 and 4"); }
            }
            return playerAmmount;
        }

        public static List<GamePlayer> GetPlayers(int playerAmmount)
        {
            var availableColors = new List<GameColor>() { 0, (GameColor)1, (GameColor)2, (GameColor)3 };
            var players = new List<GamePlayer>();
            for (int i = 0; i < playerAmmount; i++)
            {
                var newPlayer = new GamePlayer();

                // Player chooses name

                var playerName = $"Player {i + 1}";
                Console.WriteLine($"Player {i + 1} choose a name: ");
                newPlayer.Name = Console.ReadLine();

                if (newPlayer.Name == "")
                {
                    newPlayer.Name = playerName;
                }

                // Player chooses color
                Console.WriteLine($"{newPlayer.Name} choose a color:");

                for (int y = 0; y < availableColors.Count; y++)
                {
                    Console.WriteLine($"{y + 1}) {availableColors[y]}");
                }
                var colorsLeft = availableColors.Count;
                while (colorsLeft == availableColors.Count)
                    try
                    {
                        var input = Console.ReadLine();
                        if (input == "")
                            input = "1";
                        var playerColorInput = Convert.ToInt32(input) - 1;
                        newPlayer.Color = availableColors[playerColorInput];
                        availableColors.Remove(availableColors[playerColorInput]);
                    }
                    catch
                    {
                        Console.WriteLine("Input not accepted, choose an available color");
                    }

                // Add player to game players
                players.Add(newPlayer);
            }
            players = players.OrderBy(p => p.Color).ToList();
            return players;
        }

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
                    //iteration throe available pieces to se if specifik piece can be moved to target position
                    //piece can not be places att position witch already contains piece of same color
                    //piece can not jump over another piece of same color
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

        public static GamePiece GetGamePieceToMove(List<GamePiece> gamePieceSetup, GameColor color, int diceResult)
        {
            GamePiece gamePieceToMove = null;
            List<GamePiece> movablePieces = GetMovableGamePieces(gamePieceSetup, color, diceResult);
            if (movablePieces.Count != 0)
            {
                Console.WriteLine("Choose your game piece:");
                for (int i = 0; i < movablePieces.Count; i++)
                {
                    string trackPosition = (movablePieces[i].TrackPosition == null) ? "base" : "position " + (movablePieces[i].TrackPosition + 1).ToString();
                    Console.WriteLine(
                        $"{i + 1}) Piece number: {movablePieces[i].Number} at {trackPosition}");
                }
                // TODO: Input check
                var chosenPieceIndex = int.Parse(Console.ReadLine()) - 1;
                gamePieceToMove = movablePieces[chosenPieceIndex];
            }
            else
            {
                Console.WriteLine($"You don't have available moves based on dice result");
                Console.ReadKey();
            }
            return gamePieceToMove;
        }
    }
}