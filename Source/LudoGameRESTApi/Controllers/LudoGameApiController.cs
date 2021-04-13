using GameEngine.DatabaseContext;
using GameEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoGameRESTApi.Controllers
{
    public class LudoGameApiController : Controller
    {
        public string Index()
        {
            return "to get all games .../LudoGameApi/AllGames/";
        }

        // GET: /LudoGameApi/AllGames/

        public List<LudoGame> AllGames()
        {
            var db = new LudoGameDbContext();
            List<LudoGame> ludoGames = db.Games.Where(g => g.Winer == null).AsNoTracking().ToList();
            return ludoGames;
        }
    }
}