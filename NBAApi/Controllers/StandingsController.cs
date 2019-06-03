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
    public class StandingsController : ControllerBase
    {
        private readonly StandingsService _standingsService;
        private readonly IMapper _mapper;

        public StandingsController(StandingsService standingsService, IMapper mapper)
        {
            _standingsService = standingsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets nba standings
        /// </summary>
        /// <returns>IENumberable Standings</returns>
        // GET: api/StandingsDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandingsDto>>> GetStandings()
        {
            var standings = await _standingsService.GetStandingsAsync();
            if (!standings.Any())
            {
                return NotFound();
            }
            var standingsDto = _mapper.Map<IEnumerable<StandingsDto>>(standings);
            return Ok(standingsDto);
        }

        /// <summary>
        /// Gets a specific team's standings
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns>Standings</returns>
        //GET: api/StandingsDto/5
        [HttpGet("{teamID}")]
        public async Task<ActionResult<StandingsDto>> GetStandings(int teamID)
        {
            var standings = await _standingsService.GetStandingAsync(teamID);
            if (standings == null)
            {
                return NotFound();
            }
            var standingsDto = _mapper.Map<StandingsDto>(standings);
            return Ok(standingsDto);
        }
    }
}
