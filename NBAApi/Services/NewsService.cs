using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Services
{
    public class NewsService
    {
        private readonly ApplicationDBContext _context;

        public NewsService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> GetNews()
        {
            return await _context.News
                .Include(x => x.PlayerNav)
                .OrderByDescending(x => x.Updated)
                .ToListAsync();
        }

        public async Task<IEnumerable<News>> GetNewsByPlayer(int playerID)
        {
            return await _context.News
                .Include(x => x.PlayerNav)
                .Where(x => x.PlayerID == playerID)
                .OrderByDescending(x => x.Updated)
                .ToListAsync();
        }

        public async Task<IEnumerable<News>> GetNewsByTeam(int teamID)
        {
            return await _context.News
                .Include(x => x.PlayerNav)
                .Where(x => x.PlayerNav.TeamID == teamID)
                .OrderByDescending(x => x.Updated)
                .ToListAsync();
        }
    }
}
