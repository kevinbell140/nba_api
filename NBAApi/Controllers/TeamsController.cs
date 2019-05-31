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


        /// <summary>
        /// Gets a list of NBA Teams
        /// </summary>
        /// <returns>IEnumerable Teams</returns>
        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return (await _teamsService.GetTeamsAsync()).ToList();
        }


        /// <summary>
        /// Gets a specific NBA team
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
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

        /// <summary>
        /// Gets a teams PPG leader
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Player</returns>
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

        /// <summary>
        /// Gets a teams APG leader
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Player</returns>
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

        /// <summary>
        /// Gets a teams RPG leader
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Player</returns>
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

        /// <summary>
        /// Gets a teams roster
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>IEnumberable Players</returns>
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
