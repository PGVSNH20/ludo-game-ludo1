using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GamePlayers
    {
        public int GamePlayersId { get; set; }

        public List<GamePlayer> Players { get; set; }

        public int PlayerCount
        {
            get { return Players.Count; }
            set { }
        }

        public GamePlayers()
        {
            Players = new List<GamePlayer>();
        }
    }
}