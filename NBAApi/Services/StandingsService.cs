using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Services
{
    public class StandingsService
    {
        private readonly ApplicationDBContext _context;

        public StandingsService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Standings>> GetStandingsAsync()
        {
            List<Standings> standings = new List<Standings>();

            standings = await _context.Standings
                .Include(t => t.TeamNav)
                .OrderBy(t => t.TeamNav.Conference).ThenBy(x => x.GamesBack)
                .ToListAsync();

            return standings;
        }

        public async Task<Standings> GetStandingAsync(int teamID)
        {
            var standings = await _context.Standings
                .Where(t => t.TeamID == teamID)
                .FirstOrDefaultAsync();

            return standings;
        }
    }
}
