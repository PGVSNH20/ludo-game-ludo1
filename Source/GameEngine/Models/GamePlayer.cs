using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class GamePlayer
    {
        public int GamePlayerID { get; set; }
        public string Name { get; set; }
        public GameColor Color { get; set; }
        public PlayerType Type { get; set; }
    }
}