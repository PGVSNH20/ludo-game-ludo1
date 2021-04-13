using GameEngine.DatabaseContext;
using GameEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LudoGameConroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<LudoGame> Get()
        {
            var db = new LudoGameDbContext();
            List<LudoGame> ludoGames = db.Games.Where(g => g.Winer == null).AsNoTracking().ToList();
            return ludoGames;
        }
    }
}