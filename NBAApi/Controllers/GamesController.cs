using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Models;
using NBAApi.Services;

namespace NBAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameService _service;

        public GamesController(GameService service)
        {
            _service = service;
        }
        /// <summary>
        /// Gets all nba games
        /// </summary>
        /// <returns>IENumberable Games</returns>
        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            return (await _service.GetGamesAsync()).ToList();
        }


        /// <summary>
        /// Gets a specific game by the game ID
        /// </summary>
        /// <param name="id">Game ID</param>
        /// <returns>Game</returns>
        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _service.GetGameAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        /// <summary>
        /// Gets the schedule for a specific team
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns></returns>
        // GET: api/Games/team/5
        [HttpGet("team/{teamID}")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByTeam(int teamID)
        {
            var game = await _service.GetGamesByTeam(teamID);

            if (game == null)
            {
                return NotFound();
            }

            return game.ToList();
        }
    }
}
