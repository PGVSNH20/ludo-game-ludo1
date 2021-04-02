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
        public Player NextTurnPlayer { get; set; }
        public List<GamePiece> GamePieceSetUp { get; set; }

        //public string Status { get; set; }
        public LudoGame()
        {
            Moves = new List<GameMove>();
            GamePieceSetUp = GamePiece.GetGamePeaceSetUp();
            Players = new List<Player>();
        }
    }
}