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
using NBAApi.Filters;
using NBAApi.Services;

namespace NBAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamService _teamsService;
        private readonly IMapper _mapper;

        public TeamsController(TeamService teamsService, IMapper mapper)
        {
            _teamsService = teamsService;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets a list of NBA Teams
        /// </summary>
        /// <returns>IEnumerable Teams</returns>
        // GET: api/Teams
        [HttpGet]
        [ApiKeyFilter]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            var teams = await _teamsService.GetTeamsAsync();
            if (!teams.Any())
            {
                return NotFound();
            }
            var teamsDto = _mapper.Map<IEnumerable<TeamDto>>(teams);
            return Ok(teamsDto);
        }


        /// <summary>
        /// Gets a specific NBA team
        /// </summary>
        /// <param name="id">TeamDto ID</param>
        /// <returns>TeamDto</returns>
        //GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetTeamAsync(int id)
        {
            var team = await _teamsService.GetTeamAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            var teamDto = _mapper.Map<TeamDto>(team);
            return teamDto;
        }

        /// <summary>
        /// Gets a teams PPG leader
        /// </summary>
        /// <param name="id">TeamDto ID</param>
        /// <returns>PlayerDto</returns>
        //GET: api/Teams/ppg/5
        [HttpGet("ppg/{id}")]
        public async Task<ActionResult<PlayerDto>> GetPointsLeaderAsync(int id)
        {
            var leader = await _teamsService.GetPPGLeaderAsync(id);
            if (leader == null)
            {
                return NotFound();
            }
            var leaderDto = _mapper.Map<PlayerDto>(leader);
            return Ok(leaderDto);
        }

        /// <summary>
        /// Gets a teams APG leader
        /// </summary>
        /// <param name="id">TeamDto ID</param>
        /// <returns>PlayerDto</returns>
        //GET: api/Teams/apg/5
        [HttpGet("apg/{id}")]
        public async Task<ActionResult<PlayerDto>> GetAssistLeaderAsync(int id)
        {
            var leader = await _teamsService.GetAPGLeaderAsync(id);
            if (leader == null)
            {
                return NotFound();
            }
            var leaderDto = _mapper.Map<PlayerDto>(leader);
            return Ok(leaderDto);
        }

        /// <summary>
        /// Gets a teams RPG leader
        /// </summary>
        /// <param name="id">TeamDto ID</param>
        /// <returns>PlayerDto</returns>
        //GET: api/Teams/rpg/5
        [HttpGet("rpg/{id}")]
        public async Task<ActionResult<PlayerDto>> GetReboundLeaderAsync(int id)
        {
            var leader = await _teamsService.GetRPGLeaderAsync(id);
            if (leader == null)
            {
                return NotFound();
            }
            var leaderDto = _mapper.Map<PlayerDto>(leader);
            return Ok(leaderDto);
        }

        /// <summary>
        /// Gets a teams roster
        /// </summary>
        /// <param name="id">TeamDto ID</param>
        /// <returns>IEnumberable Players</returns>
        //GET: api/Teams/roster/5
        [HttpGet("roster/{id}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetRosterAsync(int id)
        {
            var roster = await _teamsService.GetRosterAsync(id);
            if (!roster.Any())
            {
                return NotFound();
            }
            var rosterDto = _mapper.Map<IEnumerable<PlayerDto>>(roster);
            return Ok(rosterDto);
        }
    }
}
