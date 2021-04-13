using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Assets
{
    public class InputDialogs
    {
        public static int GetPlayerAmount()
        {
            int playerAmount = 0;
            while (playerAmount < 2 || playerAmount > 4)
            {
                Console.WriteLine("Choose how many players (2, 3 or 4): ");
                try
                {
                    playerAmount = Convert.ToInt32(Console.ReadLine().Trim());
                    if (playerAmount >= 2 && playerAmount <= 4)
                        Console.WriteLine($"{playerAmount} players will play!");
                    else
                        Console.WriteLine("Choose between 2 and 4");
                }
                catch { Console.WriteLine("Input not accepted. Choose between 2 and 4"); }
            }
            return playerAmount;
        }

        public static List<GamePlayer> GetPlayers(int playerAmount)
        {
            var availableColors = new List<GameColor>() { 0, (GameColor)1, (GameColor)2, (GameColor)3 };
            var players = new List<GamePlayer>();
            for (int i = 0; i < playerAmount; i++)
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

                // Player chooses player type (human/robot)

                Console.WriteLine($"Choose type for {newPlayer.Name}: \r\n" +
                    $"1) Human\r\n" +
                    $"2) Robot");
                var typeInput = (int.TryParse(Console.ReadLine(), out var result)) ? result - 1 : 0;

                if (typeInput < 0 || typeInput > 1)
                    typeInput = 0;
                newPlayer.Type = (PlayerType)typeInput;

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

        public static string GetGameName()
        {
            Console.WriteLine("Name The Game: ");
            return Console.ReadLine();
        }

        public static GamePiece GetGamePieceToMove(List<GamePiece> gamePieceSetup, GameColor color, int diceResult)
        {
            GamePiece gamePieceToMove = null;
            List<GamePiece> movablePieces = Tools.GetMovableGamePieces(gamePieceSetup, color, diceResult);
            if (movablePieces.Count != 0)
            {
                Console.WriteLine("Choose your game piece:");
                for (int i = 0; i < movablePieces.Count; i++)
                {
                    string trackPosition = (movablePieces[i].TrackPosition == null) ? "base" : "position " + (movablePieces[i].TrackPosition + 1).ToString();
                    Console.WriteLine(
                        $"{i + 1}) Piece number: {movablePieces[i].Number} at {trackPosition}");
                }

                var chosenPieceIndex = (int.TryParse(Console.ReadLine(), out var result)) ? result - 1 : 0;
                if (chosenPieceIndex < 0 || chosenPieceIndex > movablePieces.Count - 1)
                    chosenPieceIndex = 0;
                gamePieceToMove = movablePieces[chosenPieceIndex];
            }
            else
            {
                Console.WriteLine($"You don't have available moves based on dice result");
                Console.ReadKey();
            }
            return gamePieceToMove;
        }

        public static LudoGame GetLudoGame(List<LudoGame> games)
        {
            Console.WriteLine("Choose game from list:");
            for (int i = 0; i < games.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {games[i].GameName} (id: {games[i].LudoGameId}), created: {games[i].Created.ToString("yyyy:MM:dd")}, status: {games[i].Status}");
            }
            var chosenGameIndex = (int.TryParse(Console.ReadLine(), out var result)) ? result - 1 : 0;
            if (chosenGameIndex < 0 || chosenGameIndex > games.Count - 1)
                chosenGameIndex = 0;
            return games[chosenGameIndex];
        }

        public static string GetPlayerMenuChoise(LudoGame game, GameBoard board)
        {
            Console.Clear();
            Tools.PrintGameDetails(game);
            Console.Write($"Now it's ");
            Tools.SetConsoleColor(game.NextPlayer.Color);
            Console.Write(game.NextPlayer.Name);
            Console.ResetColor();
            Console.WriteLine(" turn\n" +
                $"1) Throw dice\n" +
                $"2) Save game to file\n" +
                $"3) Exit game");
            board.PrintBoard(game.PieceSetup);
            string input;
            if (game.NextPlayer.Type == (PlayerType)1)
                input = "1";
            else
            {
                input = Console.ReadLine();
                input = (input == "") ? "1" : input;
            }
            return input;
        }
    }
}