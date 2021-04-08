using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    public class LudoGame
    {
        public int LudoGameId { get; set; }
        public GamePlayers GamePlayers { get; set; }
        public List<GameMove> Moves { get; set; }
        public GamePlayer Winer { get; set; }
        public string Status { get; set; }
        public List<GamePiece> PieceSetup { get; set; }
        public GamePlayer NextPlayer { get; set; }
        public string GameName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastPlayed { get; set; }

        public LudoGame()
        {
            Moves = new List<GameMove>();
            GamePlayers = new GamePlayers();
        }
    }
}