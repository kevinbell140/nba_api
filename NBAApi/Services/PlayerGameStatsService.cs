using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Services
{
    public class PlayerGameStatsService
    {
        private readonly ApplicationDBContext _context;

        public PlayerGameStatsService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerGameStats>> GetPlayerGameStats()
        {
            return await _context.PlayerGameStats
                .OrderBy(x => x.PlayerID).ThenBy(x => x.Updated)
                .ToListAsync();    
        }

        public async Task<IEnumerable<PlayerGameStats>> GetPlayerGameStatsByPlayer(int playerID)
        {
            return await _context.PlayerGameStats
                .Include(x => x.PlayerNav)
                .Where(x => x.PlayerID == playerID)
                .OrderByDescending(x => x.Updated)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerGameStats>> GetPlayerGameStatsByGame(int gameID)
        {
            return await _context.PlayerGameStats
                .Where(x => x.GameID == gameID)
                .OrderByDescending(x => x.PlayerNav.TeamID).ThenBy(x => x.PlayerID)
                .ToListAsync();
        }

        public async Task<PlayerGameStats> GetPlayerGameLog(int playerID, int gameID)
        {
            return await _context.PlayerGameStats
                .Where(x => x.GameID == gameID && x.PlayerID == playerID)
                .FirstOrDefaultAsync();
        }
    }
}
