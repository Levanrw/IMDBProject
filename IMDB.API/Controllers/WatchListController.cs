using Hangfire;
using IMDB.Models.RequestModels;
using IMDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// 
    /// </summary>
    public class WatchListController : ControllerBase
    {
        private readonly IWatchList _watchList;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="watchList"></param>
        public WatchListController(IWatchList watchList)
        {
            _watchList = watchList;
        }
        /// <summary>
        ///Add movie to watch list 
        ///</summary>
        /// <param name="request">Watch list model</param>

        [HttpPost("AddWatchList")]
        public async Task<ActionResult> AddWatchList(WatchListRequest request)
        {
            await _watchList.AddWatchList(request);
            return Ok();
        }
        /// <summary>
        /// Mark movie as watched
        /// </summary>
        /// <param name="Id"> Movie id in DB</param>
        /// <returns></returns>
        [HttpPatch("MarkAsWatched")]
        public async Task<ActionResult> MarkAsWatched(int Id)
        {
            await _watchList.MarckAsWatched(Id);
            return Ok();
        }
        /// <summary>
        /// Get watch list
        /// </summary>
        /// <param name="userId">Current user Id</param>
        /// <returns></returns>
        [HttpGet("GetWatchList")]
        public async Task<ActionResult> GetWatchList(int userId)
        {
            return Ok(await _watchList.GetWatchList(userId));
        }
        
    }
}
