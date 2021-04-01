using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class GameRunner
    {
        public LudoGame CurrentGame { get; set; }
        public GameDice Dice { get; set; }
        public GameBoard Board { get; set; }

        public GameRunner()
        {
            Dice = new GameDice();
            Board = new GameBoard();
        }

        public void CreateNewGame()
        {
            CurrentGame = new LudoGame();
            CurrentGame.Players = new List<GamePlayer>();
            for (int i = 0; i < 3; i++)
            {
                CurrentGame.Players.Add(new GamePlayer()
                {
                    GamePlayerName = $"Player {i+1}",
                    GamePlayerColour = (GameColour)i
                });
            }

            CurrentGame.PieceSetup = GamePiece.GetGamePieceSetup();

            int startingPlayerIndex = new Random().Next(0, CurrentGame.Players.Count);

            CurrentGame.NextTurnPlayer = CurrentGame.Players[startingPlayerIndex];

            CurrentGame.Moves = new List<GameMove>();
            
        }

        public void LoadGame()
        {
            //get game from db
        }

        public void PlayGame()
        {
            while(CurrentGame.Winner == null)
            {
                Console.WriteLine($"Now it's {CurrentGame.NextTurnPlayer.GamePlayerName} turn\n" +
                    $"1) Throw dice\n" +
                    $"2) Show board\n" +
                    $"3) Save game");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ThrowDice();
                        break;
                }
            }
        }

        private void ThrowDice()
        {

        }
    }
}