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
    public class PlayerSeasonStatsController : ControllerBase
    {
        private readonly PlayerSeasonStatsService _service;

        public PlayerSeasonStatsController(PlayerSeasonStatsService service)
        {
            _service = service;
        }

        // GET: api/PlayerSeasonStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerSeasonStats>>> GetPlayerSeasonStats()
        {
            return (await _service.GetStatsAsync()).ToList();
        }

        // GET: api/PlayerSeasonStats/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlayerSeasonStats>> GetPlayerSeasonStats(int id)
        {
            var playerSeasonStats = await _service.GetStatsByPlayerAsync(id);

            if (playerSeasonStats == null)
            {
                return NotFound();
            }

            return playerSeasonStats;
        }

        // GET: api/PlayerSeasonStats/John
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<PlayerSeasonStats>>> GetPlayerSeasonStats(string name)
        {
            var playerSeasonStats = await _service.GetStatsByPlayerAsync(name);

            if (playerSeasonStats == null)
            {
                return NotFound();
            }

            return playerSeasonStats.ToList();
        }
    }
}
