using System;
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

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
            return (await _playerService.GetPlayersAsync()).ToList();
        }

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

        //// PUT: api/Players/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlayer(int id, Player player)
        //{
        //    if (id != player.PlayerID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(player).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Players
        //[HttpPost]
        //public async Task<ActionResult<Player>> PostPlayer(Player player)
        //{
        //    _context.Player.Add(player);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PlayerExists(player.PlayerID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetPlayer", new { id = player.PlayerID }, player);
        //}

        //// DELETE: api/Players/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Player>> DeletePlayer(int id)
        //{
        //    var player = await _context.Player.FindAsync(id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Player.Remove(player);
        //    await _context.SaveChangesAsync();

        //    return player;
        //}

        //private bool PlayerExists(int id)
        //{
        //    return _context.Player.Any(e => e.PlayerID == id);
        //}
    }
}
