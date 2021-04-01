using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class GameRunner
    {
        public LudoGame Game { get; set; }
        public GameDice Dice { get; set; }
        public GameBoard Board { get; set; }

        public GameRunner()
        {
            Game = new LudoGame();
            Dice = new GameDice();
            Board = new GameBoard();
        }

        public GameRunner CreateNewGame()
        {
            Console.WriteLine("Please choose player count");
            int playerCount = int.Parse(Console.ReadLine());
            var availableColors = new List<GameColor>() {
                0, (GameColor)1, (GameColor)2, (GameColor)3,
            };

            for (var i = 1; i <= playerCount; i++)
            {
                Console.Write($"player{i}, write your name: ");
                var playerName = Console.ReadLine();
                playerName = (playerName == string.Empty) ? $"player{i}" : playerName;

                Console.WriteLine($"{playerName}, chose your color: ");

                for (int index = 1; index <= availableColors.Count; index++)
                {
                    Console.WriteLine($"{index}: {availableColors[index - 1]}");
                }
                if (!Int32.TryParse(Console.ReadLine(), out int colorIndex))
                    colorIndex = 1;
                var chosenColor = availableColors[colorIndex - 1];
                availableColors.Remove(chosenColor);
                Game.Players.Add(new Player()
                {
                    Name = playerName,
                    Color = chosenColor,
                });
            }
            Game.Players = Game.Players.OrderBy(p => p.Color).ToList();
            var startingPlayerIndex = new Random().Next(0, Game.Players.Count);
            Game.NextTurnPlayer = Game.Players[startingPlayerIndex];
            //save db
            return this;
        }

        public GameRunner LoadGame()
        {
            Console.WriteLine("You can choose from these games");
            //list from db
            //Game = db....
            return this;
        }

        public GameRunner PlayGame()
        {
            while (Game.Winner == null)
            {
                Console.WriteLine(
                    $"{Game.NextTurnPlayer.Name}'s turn. Whats your move, {Game.NextTurnPlayer.Name}?\n" +
                    $"[1] Show game board\n" +
                    $"[2] Throw dice\n" +
                    $"[3] Pause game\n");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Board.PrintBoard();
                        break;

                    case 2:
                        //ThrowDice
                        ThrowDice();
                        MakeMove();
                        Game.NextTurnPlayer = Game.Players[(Game.Players.IndexOf(Game.NextTurnPlayer) + 1) % Game.Players.Count];
                        Console.WriteLine("player changed");
                        break;

                    case 3:
                        //PauseGame
                        break;

                    default:
                        //wrong numer
                        break;
                }
            }
            return this;
        }

        private void ThrowDice()
        {
            Dice.TrowDice();
            Console.WriteLine($"Nice, {Game.NextTurnPlayer.Name}, you throw {Dice.Result}");
        }

        private void MakeMove()
        {
            Console.WriteLine($"Which game piece you want to move?");
            foreach (var gamePeace in Game.GamePeaceSetUp.FindAll(p => p.Color == Game.NextTurnPlayer.Color))
            {
                Console.WriteLine($"Game piece number: {gamePeace.Number} currently att position {gamePeace.Possition}");
            }
            var gameMove = new GameMove();
            gameMove.Player = Game.NextTurnPlayer;
            int userChoise = int.Parse(Console.ReadLine());
            gameMove.GamePiece = Game.GamePeaceSetUp.Find(p => (p.Color == Game.NextTurnPlayer.Color && p.Number == userChoise));
            if (gameMove.GamePiece.Possition == null)
                gameMove.GamePiece.Possition = Dice.Result;
            else
                gameMove.GamePiece.Possition += Dice.Result;

            UppdateBoardTrack(gameMove.GamePiece);

            Game.Moves.Add(gameMove);
        }

        private void UppdateBoardTrack(GamePiece currentGamePiece)
        {
            var boardTrackIndex = (int)currentGamePiece.Possition + (10 * (int)currentGamePiece.Color) % 40;
            if (Board.Track[boardTrackIndex] != null)
                Board.Track[boardTrackIndex].Possition = null;
            Board.Track[boardTrackIndex] = currentGamePiece;
        }
    }
}