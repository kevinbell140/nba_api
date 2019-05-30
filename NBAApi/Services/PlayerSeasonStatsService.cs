using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Services
{
    public class PlayerSeasonStatsService
    {
        private readonly ApplicationDBContext _context;

        public PlayerSeasonStatsService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerSeasonStats>> GetStatsAsync()
        {
            return await _context.PlayerSeasonStats
                .Include(x => x.PlayNav)
                .ToListAsync();
        }

        public async Task<PlayerSeasonStats> GetStatsByPlayerAsync(int playerID)
        {
            var stats = await _context.PlayerSeasonStats
                .Include(x => x.PlayNav)
                .Where(x => x.PlayerID == playerID)
                .FirstOrDefaultAsync();
            return stats;
        }

        public async Task<IEnumerable<PlayerSeasonStats>> GetStatsByPlayerAsync(string name)
        {
            var stats = await _context.PlayerSeasonStats
                .Include(x => x.PlayNav)
                .Where(x => x.PlayNav.FullName == name)
                .ToListAsync();
            return stats;
        }
    }
}
