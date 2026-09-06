using GameLauncher.Data;
using GameLauncher.Models;
using GameLauncher.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace GameLauncher.Controller{

    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetGames()
        {
            return Ok(_context.Games.ToList());
        }
        
        [HttpPost]
        public IActionResult AddGame(GameDTO dto)
        {
            var GameExist = _context.Games.Any(game => game.Title == dto.Title);

            if(GameExist)
            {
            return BadRequest("This Game alredy exist");
            }
     
             var game = new Game
             {
                Title = dto.Title,
             };

             _context.Games.Add(game);
             _context.SaveChanges();

             return Created("", game);
        }
    }
}