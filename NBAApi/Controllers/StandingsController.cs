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
        public async Task<ActionResult<IEnumerable<Standings>>> GetStandings([FromQuery] string conference)
        {
            if(conference == null)
            {
                return BadRequest();
            }
            return (await _standingsService.GetStandingsAsync(conference)).ToList();
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

        // //PUT: api/Standings/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutStandings(int id, Standings standings)
        // {
        //     if (id != standings.TeamID)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(standings).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!StandingsExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // //POST: api/Standings
        //[HttpPost]
        // public async Task<ActionResult<Standings>> PostStandings(Standings standings)
        // {
        //     _context.Standings.Add(standings);
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateException)
        //     {
        //         if (StandingsExists(standings.TeamID))
        //         {
        //             return Conflict();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return CreatedAtAction("GetStandings", new { id = standings.TeamID }, standings);
        // }

        // //DELETE: api/Standings/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Standings>> DeleteStandings(int id)
        // {
        //     var standings = await _context.Standings.FindAsync(id);
        //     if (standings == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Standings.Remove(standings);
        //     await _context.SaveChangesAsync();

        //     return standings;
        // }

        //private bool StandingsExists(int id)
        //{
        //    return _context.Standings.Any(e => e.TeamID == id);
        //}
    }
}
