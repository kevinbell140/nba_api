using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Dtos;
using NBAApi.Data.Models;
using NBAApi.Services;

namespace NBAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameService _service;
        private readonly IMapper _mapper;

        public GamesController(GameService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all nba games
        /// </summary>
        /// <returns>IENumberable Games</returns>
        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGame()
        {
            var games = await _service.GetGamesAsync();
            if (!games.Any())
            {
                return NotFound();
            }
            var gamesDto = _mapper.Map<IEnumerable<GameDto>>(games);
            return Ok(gamesDto);

        }


        /// <summary>
        /// Gets a specific game by the game ID
        /// </summary>
        /// <param name="id">GameDto ID</param>
        /// <returns>GameDto</returns>
        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            var game = await _service.GetGameAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            var gameDto = _mapper.Map<GameDto>(game);
            return Ok(gameDto);
        }

        /// <summary>
        /// Gets the schedule for a specific team
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns></returns>
        // GET: api/Games/team/5
        [HttpGet("team/{teamID}")]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGamesByTeam(int teamID)
        {
            var games = await _service.GetGamesByTeam(teamID);

            if (!games.Any())
            {
                return NotFound();
            }

            var gamesDto = _mapper.Map<IEnumerable<GameDto>>(games);
            return Ok(gamesDto);
        }
    }
}
