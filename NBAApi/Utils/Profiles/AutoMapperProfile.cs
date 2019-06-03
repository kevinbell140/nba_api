using AutoMapper;
using NBAApi.Data.Dtos;
using NBAApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Utils.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();

            CreateMap<News, NewsDto>();
            CreateMap<NewsDto, News>();

            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();

            CreateMap<PlayerGameStats, PlayerGameStatsDto>();
            CreateMap<PlayerGameStatsDto, PlayerGameStats>();

            CreateMap<PlayerSeasonStats, PlayerGameStatsDto>();
            CreateMap<PlayerSeasonStatsDto, PlayerSeasonStats>();

            CreateMap<Standings, StandingsDto>();
            CreateMap<StandingsDto, Standings>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();
        }
    }
}
