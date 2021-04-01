using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class LudoGame
    {
        public int LudoGameId { get; set; }
        public List<GamePlayer> Players { get; set; }
        public List<GameMove> Moves { get; set; }
        public GamePlayer Winner { get; set; }
        public string Status { get; set; }
        public List<GamePiece> PieceSetup { get; set; }
        public GamePlayer NextTurnPlayer { get; set; }
    }
}