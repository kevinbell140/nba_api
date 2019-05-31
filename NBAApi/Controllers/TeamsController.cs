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
    public class TeamsController : ControllerBase
    {
        private readonly TeamService _teamsService;

        public TeamsController(TeamService teamsService)
        {
            _teamsService = teamsService;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams([FromQuery]string sortOrder)
        {
            return (await _teamsService.GetTeamsAsync(sortOrder)).ToList();
        }


        //GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeamAsync(int id)
        {
            var team = await _teamsService.GetTeamAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        //GET: api/Teams/ppg/5
        [HttpGet("ppg/{id}")]
        public async Task<ActionResult<Player>> GetPointsLeaderAsync(int id)
        {
            var leader = await _teamsService.GetPPGLeaderAsync(id);

            if (leader == null)
            {
                return NotFound();
            }

            return leader;
        }

        //GET: api/Teams/apg/5
        [HttpGet("apg/{id}")]
        public async Task<ActionResult<Player>> GetAssistLeaderAsync(int id)
        {
            var leader = await _teamsService.GetAPGLeaderAsync(id);

            if (leader == null)
            {
                return NotFound();
            }

            return leader;
        }


        //GET: api/Teams/rpg/5
        [HttpGet("rpg/{id}")]
        public async Task<ActionResult<Player>> GetReboundLeaderAsync(int id)
        {
            var leader = await _teamsService.GetRPGLeaderAsync(id);

            if (leader == null)
            {
                return NotFound();
            }

            return leader;
        }

        //GET: api/Teams/roster/5
        [HttpGet("roster/{id}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetRosterAsync(int id)
        {
            var leader = await _teamsService.GetRosterAsync(id);

            if (leader == null)
            {
                return NotFound();
            }

            return leader.ToList();
        }
    }
}
