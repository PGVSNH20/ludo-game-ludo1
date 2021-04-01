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
        public AiPlayer Ai { get; set; }

        public GameRunner()
        {
            Game = new LudoGame();
            Dice = new GameDice();
            Board = new GameBoard();
            Ai = new AiPlayer(Board, Game.GamePeaceSetUp);
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
                Console.Clear();
                Board.PrintBoard(Game.GamePeaceSetUp);
                Console.WriteLine(
                    $"{Game.NextTurnPlayer.Name}'s turn. Whats your move, {Game.NextTurnPlayer.Name}?\n" +
                    $"[1] Throw dice\n" +
                    $"[2] Pause game\n");
                var turnChoise = (Game.NextTurnPlayer.Name.ToLower() == "ai") ? "1" : Console.ReadLine();
                switch ((turnChoise == string.Empty) ? 1 : int.Parse(turnChoise))
                {
                    case 1:
                        ThrowDice();
                        MakeMove();
                        Game.NextTurnPlayer = Game.Players[(Game.Players.IndexOf(Game.NextTurnPlayer) + 1) % Game.Players.Count];
                        Console.WriteLine("player changed");
                        break;

                    case 2:
                        //save game
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

            var userChoise = (Game.NextTurnPlayer.Name.ToLower() == "ai") ? Ai.ChoosePieceToMove(Game.NextTurnPlayer.Color) : Console.ReadLine();

            gameMove.GamePiece = Game.GamePeaceSetUp
                .Find(p => (
                    p.Color == Game.NextTurnPlayer.Color
                    && p.Number == (
                        (userChoise == string.Empty) ? 1 : int.Parse(userChoise))));
            int oldPossition;
            if (gameMove.GamePiece.Possition == null)
            {
                gameMove.GamePiece.Possition = Dice.Result - 1;
                oldPossition = (int)gameMove.GamePiece.Possition;
            }
            else
            {
                oldPossition = (int)gameMove.GamePiece.Possition;
                gameMove.GamePiece.Possition += Dice.Result;
            }

            UppdateBoardTrack(gameMove.GamePiece, oldPossition);

            Game.Moves.Add(gameMove);
        }

        private void UppdateBoardTrack(GamePiece currentGamePiece, int oldPossition)
        {
            if (oldPossition >= 0 && oldPossition < 40)
            {
                var oldBoardTrackIndex = (oldPossition + 10 * (int)currentGamePiece.Color) % 40;
                Board.Track[oldBoardTrackIndex] = null;
            }
            else if (oldPossition >= 40)
            {
                Board.FinalTracks[(int)currentGamePiece.Color, oldPossition - 40] = null;
            }

            if (currentGamePiece.Possition >= 0 && currentGamePiece.Possition < 40)
            {
                var boardTrackIndex = ((int)currentGamePiece.Possition + 10 * (int)currentGamePiece.Color) % 40;
                Board.Track[boardTrackIndex] = currentGamePiece;
            }
            else if (currentGamePiece.Possition >= 40 && currentGamePiece.Possition < 44)
            {
                Board.FinalTracks[(int)currentGamePiece.Color, (int)currentGamePiece.Possition - 40] = currentGamePiece;
            }
        }
    }
}