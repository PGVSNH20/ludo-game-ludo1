using GameEngine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Models
{
    internal class LudoGameDbContext : DbContext
    {
        public DbSet<GamePlayer> Players { get; set; }

        public DbSet<LudoGame> Games { get; set; }
        public DbSet<GameMove> Moves { get; set; }
        public DbSet<GamePlayers> GamePlayers { get; set; }

        public DbSet<GamePiece> GamePieces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=LudoGameDb_edgar;User Id=sa;Password=My!P@ssw0rd1;");
        }
    }
}