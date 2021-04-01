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
        }

        public void LoadGame()
        {
            //get game from db
        }
    }
}