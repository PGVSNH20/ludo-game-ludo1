using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class LudoGame
    {
        public int LudoGameId { get; set; }
        public List<Player> Players { get; set; }
        public List<GameMove> Moves { get; set; }
        public Player Winner { get; set; }
        public List<GamePeace> GamePeaceSetUp { get; set; }

        //public string Status { get; set; }
        public LudoGame()
        {
            Moves = new List<GameMove>();
            GamePeaceSetUp = new GamePeace().GetGamePeaceSetUp();
            Players = new List<Player>();
        }
    }
}