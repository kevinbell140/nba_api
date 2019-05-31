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
    public class PlayerGameStatsController : ControllerBase
    {
        private readonly PlayerGameStatsService _service;

        public PlayerGameStatsController(PlayerGameStatsService service)
        {
            _service = service;
        }


        /// <summary>
        /// Gets all game logs
        /// </summary>
        /// <returns>IENumberable Logs</returns>
        // GET: api/PlayerGameStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerGameStats>>> GetPlayerGameStats()
        {
            return (await _service.GetPlayerGameStats()).ToList();
        }


        /// <summary>
        /// Gets game logs for a specific player
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns>IENumberable Logs</returns>
        // GET: api/PlayerGameStats/5
        [HttpGet("player/{playerID}")]
        public async Task<ActionResult<IEnumerable<PlayerGameStats>>> GetPlayerGameStatsByPlayer(int playerID)
        {
            var playerGameStats = await _service.GetPlayerGameStatsByPlayer(playerID);

            if (playerGameStats == null)
            {
                return NotFound();
            }

            return playerGameStats.ToList();
        }

        /// <summary>
        /// Gets game logs for a specific game
        /// </summary>
        /// <param name="gameID"></param>
        /// <returns>IENumberable Logs</returns>
        // GET: api/PlayerGameStats/5
        [HttpGet("game/{gameID}")]
        public async Task<ActionResult<IEnumerable<PlayerGameStats>>> GetPlayerGameStatsByGame(int gameID)
        {
            var playerGameStats = await _service.GetPlayerGameStatsByGame(gameID);

            if (playerGameStats == null)
            {
                return NotFound();
            }
            return playerGameStats.ToList();
        }

        /// <summary>
        /// Gets a game log for a specific player and game
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="gameID"></param>
        /// <returns>Game log</returns>
        // GET: api/PlayerGameStats/5
        [HttpGet("player/{playerID}/game/{gameID}")]
        public async Task<ActionResult<PlayerGameStats>> GetGameLog(int playerID, int gameID)
        {
            var playerGameStats = await _service.GetPlayerGameLog(playerID, gameID);

            if (playerGameStats == null)
            {
                return NotFound();
            }
            return playerGameStats;
        }
    }
}
