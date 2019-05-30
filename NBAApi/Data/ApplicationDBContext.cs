using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBAApi.Data.Models;
using NBAApi.Data;

namespace NBAApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<NBAApi.Data.Models.Team> Team { get; set; }
        public DbSet<NBAApi.Data.Models.Standings> Standings { get; set; }
        public DbSet<NBAApi.Data.Player> Player { get; set; }
        public DbSet<NBAApi.Data.Models.PlayerSeasonStats> PlayerSeasonStats { get; set; }
        public DbSet<NBAApi.Data.Models.Game> Game { get; set; }

        public DbSet<NBAApi.Data.Models.PlayerGameStats> PlayerGameStats { get; set; }

        public DbSet<NBAApi.Data.Models.News> News { get; set; }
    }
}
