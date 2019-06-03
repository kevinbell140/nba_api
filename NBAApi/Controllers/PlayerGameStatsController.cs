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
    public class PlayerGameStatsController : ControllerBase
    {
        private readonly PlayerGameStatsService _service;
        private readonly IMapper _mapper;

        public PlayerGameStatsController(PlayerGameStatsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets all game logs
        /// </summary>
        /// <returns>IENumberable Logs</returns>
        // GET: api/PlayerGameStatsDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerGameStatsDto>>> GetPlayerGameStats()
        {
            var stats = await _service.GetPlayerGameStats();
            if (!stats.Any())
            {
                return NotFound();
            }
            var statsDto = _mapper.Map<IEnumerable<PlayerGameStatsDto>>(stats);
            return Ok(statsDto);
        }


        /// <summary>
        /// Gets game logs for a specific player
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns>IENumberable Logs</returns>
        // GET: api/PlayerGameStatsDto/5
        [HttpGet("player/{playerID}")]
        public async Task<ActionResult<IEnumerable<PlayerGameStatsDto>>> GetPlayerGameStatsByPlayer(int playerID)
        {
            var stats = await _service.GetPlayerGameStatsByPlayer(playerID);
            if (!stats.Any())
            {
                return NotFound();
            }
            var statsDto = _mapper.Map<IEnumerable<PlayerGameStatsDto>>(stats);
            return Ok(statsDto);
        }

        /// <summary>
        /// Gets game logs for a specific game
        /// </summary>
        /// <param name="gameID"></param>
        /// <returns>IENumberable Logs</returns>
        // GET: api/PlayerGameStatsDto/5
        [HttpGet("game/{gameID}")]
        public async Task<ActionResult<IEnumerable<PlayerGameStats>>> GetPlayerGameStatsByGame(int gameID)
        {
            var stats = await _service.GetPlayerGameStatsByGame(gameID);
            if (!stats.Any())
            {
                return NotFound();
            }
            var statsDto = _mapper.Map<IEnumerable<PlayerGameStatsDto>>(stats);
            return Ok(statsDto);
        }

        /// <summary>
        /// Gets a game log for a specific player and game
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="gameID"></param>
        /// <returns>GameDto log</returns>
        // GET: api/PlayerGameStatsDto/5
        [HttpGet("player/{playerID}/game/{gameID}")]
        public async Task<ActionResult<PlayerGameStats>> GetGameLog(int playerID, int gameID)
        {
            var stats = await _service.GetPlayerGameLog(playerID, gameID);
            if (stats == null)
            {
                return NotFound();
            }
            var statsDto = _mapper.Map<PlayerGameStatsDto>(stats);
            return Ok(statsDto);
        }
    }
}
