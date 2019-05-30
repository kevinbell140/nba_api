using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Services
{
    public class GameService
    {
        private readonly ApplicationDBContext _context;

        public GameService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Game.ToListAsync();
        }

        public async Task<Game> GetGameAsync(int gameID)
        {
            var game = await _context.Game
                .Include(x => x.AwayTeamNav)
                .Include(x => x.HomeTeamNav)
                .Where(x => x.GameID == gameID)
                .FirstOrDefaultAsync();
            return game;
        }

        public async Task<IEnumerable<Game>> GetGamesByTeam(int teamID)
        {
            var games = await _context.Game
                .Include(x => x.AwayTeamNav)
                .Include(x => x.HomeTeamNav)
                .Where(x => x.AwayTeamID == teamID || x.HomeTeamID == teamID)
                .OrderByDescending(x => x.DateTime)
                .ToListAsync();
            return games;
        }
    }
}
