using GameEngine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.DatabaseContext
{
    internal class LudoGameDbContext : DbContext
    {
        public DbSet<GamePlayer> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=LudoGameDb;User Id=sa;Password=My!P@ssw0rd1;");
        }
    }
}