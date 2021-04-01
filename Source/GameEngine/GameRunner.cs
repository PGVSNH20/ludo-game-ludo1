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
            
        }

        public void LoadGame()
        {
            //get game from db
        }
    }
}