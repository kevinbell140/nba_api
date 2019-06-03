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
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(PlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all players
        /// </summary>
        /// <returns>IENumberable PlayerDto</returns>
        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayer()
        {
            var players = await _playerService.GetPlayersAsync();
            if (!players.Any())
            {
                return NotFound();
            }
            var playerDto = _mapper.Map<IEnumerable<PlayerDto>>(players);
            return Ok(playerDto);
        }

        /// <summary>
        /// Gets a specific player
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PlayerDto</returns>
        // GET: api/Players/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlayerDto>> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerByIDAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            var playerDto = _mapper.Map<PlayerDto>(player);
            return Ok(playerDto);
        }

        /// <summary>
        /// Gets a list of players matching a name input
        /// </summary>
        /// <param name="name"></param>
        /// <returns>IENumberable PlayerDto</returns>
        // GET: api/Players/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayer(string name)
        {
            var players = await _playerService.GetPlayerByNameAsync(name);
            if (!players.Any())
            {
                return NotFound();
            }
            var playersDto = _mapper.Map<IEnumerable<PlayerDto>>(players);
            return Ok(playersDto);
        }
    }
}
