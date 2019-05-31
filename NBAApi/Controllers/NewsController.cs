using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Data.Models;
using NBAApi.Services;

namespace NBAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _service;

        public NewsController(NewsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all news
        /// </summary>
        /// <returns>IENumberable News</returns>
        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return (await _service.GetNews()).ToList();
        }

        /// <summary>
        /// Gets news by specific player
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns>IENumberable News</returns>
        // GET: api/News/player/5
        [HttpGet("player/{playerID}")]
        public async Task<ActionResult<IEnumerable<News>>> GetNewsByPlayer(int playerID)
        {
            var news = await _service.GetNewsByPlayer(playerID);

            if (news == null)
            {
                return NotFound();
            }

            return news.ToList();
        }


        //// GET: api/News/player/5
        //[HttpGet("team/{teamID}")]
        //public async Task<ActionResult<IEnumerable<News>>> GetNewsByTeam(int teamID)
        //{
        //    var news = await _service.GetNewsByPlayer(teamID);

        //    if (!news.Any())
        //    {
        //        return NotFound();
        //    }

        //    return news.ToList();
        //}
    }
}
