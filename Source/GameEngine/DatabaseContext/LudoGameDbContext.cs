using GameEngine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.DatabaseContext
{
    public class LudoGameDbContext : DbContext
    {
        public DbSet<GamePlayer> Players { get; set; }
        public DbSet<GamePlayers> PlayersInGame { get; set; }
        public DbSet<LudoGame> Games { get; set; }
        public DbSet<GameMove> GameMoves { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }

        public LudoGameDbContext()
        {
        }

        public LudoGameDbContext(DbContextOptions<LudoGameDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer(@"Server=localhost;Database=LudoGameDb;User Id=sa;Password=My!P@ssw0rd1;");
        }
    }
}