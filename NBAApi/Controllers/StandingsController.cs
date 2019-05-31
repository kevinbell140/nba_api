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
    public class StandingsController : ControllerBase
    {
        private readonly StandingsService _standingsService;

        public StandingsController(StandingsService standingsService)
        {
            _standingsService = standingsService;
        }

        // GET: api/Standings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Standings>>> GetStandings()
        {
            return (await _standingsService.GetStandingsAsync()).ToList();
        }

        //GET: api/Standings/5
        [HttpGet("{teamID}")]
        public async Task<ActionResult<Standings>> GetStandings(int teamID)
        {
            var standings = await _standingsService.GetStandingAsync(teamID);

            if (standings == null)
            {
                return NotFound();
            }

            return standings;
        }
    }
}
