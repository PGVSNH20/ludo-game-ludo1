using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class GameRunner
    {
        public LudoGame Game { get; set; }
        public GameDice Dice { get; set; }
        public GameBoard Board { get; set; }
        public Player CurrentPlayer { get; set; }

        public GameRunner()
        {
            Game = new LudoGame();
            Dice = new GameDice();
        }

        public GameRunner CreateNewGame()
        {
            Console.WriteLine("Please choose player count");
            int playerCount = int.Parse(Console.ReadLine());
            var availableColors = new List<GamePieceColor>() {
                0, (GamePieceColor)1, (GamePieceColor)2, (GamePieceColor)3,
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

                int colorIndex = int.Parse(Console.ReadLine());
                var chosenColor = availableColors[colorIndex - 1];
                availableColors.Remove(chosenColor);
                Game.Players.Add(new Player()
                {
                    Name = playerName,
                    Color = chosenColor,
                });
            }
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
            CurrentPlayer = Game.Players[0];
            while (Game.Winner == null)
            {
                Console.WriteLine(
                    $"{CurrentPlayer.Name}'s turn. Whats your move, {CurrentPlayer.Name}?\n" +
                    $"[1] Show game board\n" +
                    $"[2] Throw dice\n" +
                    $"[3] Pause game\n");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        //ShowBoard
                        break;

                    case 2:
                        //ThrowDice
                        ThrowDice();
                        MakeMove();
                        break;

                    case 3:
                        //PauseGame
                        break;

                    default:
                        //wrong numer
                        break;
                }
                CurrentPlayer = Game.Players[(Game.Players.IndexOf(CurrentPlayer) + 1) % Game.Players.Count];
                Console.WriteLine("player changed");
            }
            return this;
        }

        private void ThrowDice()
        {
            Dice.ThrowValue = 4;
            Console.WriteLine($"Nice, {CurrentPlayer.Name}, you throw {Dice.ThrowValue}");
        }

        private void MakeMove()
        {
            Console.WriteLine($"Which game piece you want to move?");
            foreach (var gamePeace in Game.GamePeaceSetUp.FindAll(p => p.Color == CurrentPlayer.Color))
            {
                Console.WriteLine($"Game piece number: {gamePeace.Number} currently att position {gamePeace.TrackPossition}");
            }
            var gameMove = new GameMove();
            gameMove.Player = CurrentPlayer;
            int userChoise = int.Parse(Console.ReadLine());
            var currentGamePeace = Game.GamePeaceSetUp.Find(p => (p.Color == CurrentPlayer.Color && p.Number == userChoise));
            var currentGamePeaceIndex = Game.GamePeaceSetUp.IndexOf(currentGamePeace);
            gameMove.GamePeace = Game.GamePeaceSetUp[currentGamePeaceIndex];

            gameMove.DiceThrow = Dice.ThrowValue;
            Game.GamePeaceSetUp[currentGamePeaceIndex].TrackPossition += Dice.ThrowValue;
            Game.Moves.Add(gameMove);
        }
    }
}