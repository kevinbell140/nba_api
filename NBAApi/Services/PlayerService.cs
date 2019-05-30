using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Services
{
    public class PlayerService
    {
        private readonly ApplicationDBContext _context;

        public PlayerService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _context.Player.ToListAsync();
        }

        public async Task<Player> GetPlayerByIDAsync(int playerID)
        {
            var player = await _context.Player
                .Where(x => x.PlayerID == playerID)
                .FirstOrDefaultAsync();
            return player;

        }

        public async Task<IEnumerable<Player>> GetPlayerByNameAsync(string name)
        {
            var players = await _context.Player
                .Where(x => x.FullName.ToLower().Contains(name.ToLower()))
                .ToListAsync();
            return players;
        }
    }
}
