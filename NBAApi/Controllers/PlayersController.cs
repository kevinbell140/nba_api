﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Services;

namespace NBAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        /// <summary>
        /// Gets all players
        /// </summary>
        /// <returns>IENumberable Player</returns>
        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
            return (await _playerService.GetPlayersAsync()).ToList();
        }

        /// <summary>
        /// Gets a specific player
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Player</returns>
        // GET: api/Players/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerByIDAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        /// <summary>
        /// Gets a list of players matching a name input
        /// </summary>
        /// <param name="name"></param>
        /// <returns>IENumberable Player</returns>
        // GET: api/Players/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer(string name)
        {
            var player = await _playerService.GetPlayerByNameAsync(name);

            if (player == null)
            {
                return NotFound();
            }

            return player.ToList();
        }
    }
}
