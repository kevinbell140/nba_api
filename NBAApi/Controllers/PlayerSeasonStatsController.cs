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
    public class PlayerSeasonStatsController : ControllerBase
    {
        private readonly PlayerSeasonStatsService _service;
        private readonly IMapper _mapper;

        public PlayerSeasonStatsController(PlayerSeasonStatsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all season stats
        /// </summary>
        /// <returns>IENumberable Season Stats</returns>
        // GET: api/PlayerSeasonStatsDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerSeasonStatsDto>>> GetPlayerSeasonStats()
        {
            var stats = await _service.GetStatsAsync();
            if (!stats.Any())
            {
                return NotFound();
            }
            var statsDto = _mapper.Map<IEnumerable<PlayerSeasonStatsDto>>(stats);
            return Ok(statsDto);
        }

        /// <summary>
        /// Gets the season stats for a specific player
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Season stats</returns>
        // GET: api/PlayerSeasonStatsDto/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlayerSeasonStatsDto>> GetPlayerSeasonStats(int id)
        {
            var stats = await _service.GetStatsByPlayerAsync(id);
            if (stats == null)
            {
                return NotFound();
            }
            var statsDto = _mapper.Map<PlayerGameStatsDto>(stats);
            return Ok(statsDto);
        }

        /// <summary>
        /// Gets the season stats for a specific player by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Season stats</returns>
        // GET: api/PlayerSeasonStatsDto/John
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<PlayerSeasonStatsDto>>> GetPlayerSeasonStats(string name)
        {
            var stats = await _service.GetStatsByPlayerAsync(name);
            if (!stats.Any())
            {
                return NotFound();
            }
            var statsDto = _mapper.Map<IEnumerable<PlayerGameStatsDto>>(stats);
            return Ok(statsDto);
        }
    }
}
