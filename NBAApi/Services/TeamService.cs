using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Services
{
    public class TeamService
    {
        private readonly ApplicationDBContext _context;

        public TeamService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Team> GetTeamAsync(int id)
        {
            var team = await _context.Team
                .Where(t => t.TeamID == id)
                .FirstOrDefaultAsync();

            return team;
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync(string sortOrder)
        {
            var teams = _context.Team.AsNoTracking();
            if (teams != null && await teams.AnyAsync())
            {
                switch (sortOrder)
                {
                    case "city_desc":
                        teams = teams.OrderByDescending(t => t.City);
                        break;
                    case "Name":
                        teams = teams.OrderBy(t => t.Name);
                        break;
                    case "name_desc":
                        teams = teams.OrderByDescending(t => t.Name);
                        break;
                    case "Division":
                        teams = teams.OrderBy(t => t.Division);
                        break;
                    case "division_desc":
                        teams = teams.OrderByDescending(t => t.Division);
                        break;
                    default:
                        teams = teams.OrderBy(t => t.City);
                        break;
                }
            }
            return teams;
        }

        public async Task<Player> GetPPGLeaderAsync(int teamID)
        {
            Player leader = await _context.Player
                .Where(p => p.StatsNav != null && p.TeamID == teamID)
                .OrderByDescending(p => p.StatsNav.PPG)
                .FirstOrDefaultAsync();
            return leader;
        }

        public async Task<Player> GetRPGLeaderAsync(int teamID)
        {
            Player leader = await _context.Player
                .Where(p => p.StatsNav != null && p.TeamID == teamID)
                .OrderByDescending(p => p.StatsNav.RPG)
                .FirstOrDefaultAsync();
            return leader;
        }

        public async Task<Player> GetAPGLeaderAsync(int teamID)
        {
            Player leader = await _context.Player
                .Where(p => p.StatsNav != null && p.TeamID == teamID)
                .OrderByDescending(p => p.StatsNav.APG)
                .FirstOrDefaultAsync();
            return leader;
        }

        public async Task<IEnumerable<Player>> GetRosterAsync(int teamID)
        {
            var roster = await _context.Player
                .Where(p => p.TeamID == teamID)
                .OrderByDescending(p => p.Position)
                .ToListAsync();
            return roster;
        }

        //public async Task FetchAsync()
        //{
        //    List<Team> teams = await _dataService.FetchTeamsAsync();
        //    List<Team> created = new List<Team>();
        //    List<Team> updated = new List<Team>();

        //    foreach (Team t in teams)
        //    {
        //        if (!await _context.Team.AnyAsync(o => o.TeamID == t.TeamID))
        //        {
        //            created.Add(t);
        //        }
        //        else
        //        {
        //            updated.Add(t);
        //        }
        //    }
        //    try
        //    {
        //        await _context.AddRangeAsync(created);
        //        _context.UpdateRange(updated);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }
        //}
    }
}
