using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Dtos;
using NBAApi.Data.Models;
using NBAApi.Services;

namespace NBAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _service;
        private readonly IMapper _mapper;

        public NewsController(NewsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all news
        /// </summary>
        /// <returns>IENumberable News</returns>
        // GET: api/NewsDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews()
        {
            var news = await _service.GetNews();
            if (!news.Any())
            {
                return NotFound();
            }
            var newsDto = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDto);

        }

        /// <summary>
        /// Gets news by specific player
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns>IENumberable News</returns>
        // GET: api/NewsDto/player/5
        [HttpGet("player/{playerID}")]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetNewsByPlayer(int playerID)
        {
            var news = await _service.GetNewsByPlayer(playerID);
            if (!news.Any())
            {
                return NotFound();
            }
            var newsDto = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDto);
        }
    }
}
