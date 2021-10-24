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
    public class WatchListController : ControllerBase
    {
        private readonly IWatchList _watchList;

        public WatchListController(IWatchList watchList)
        {
            _watchList = watchList;
        }

        [HttpPost("AddWatchList")]
        public async Task<ActionResult> AddWatchList(WatchListRequest request)
        {
            await _watchList.AddWatchList(request);
            return Ok();
        }
        [HttpPatch("MarkAsWatched")]
        public async Task<ActionResult> MarkAsWatched(int Id)
        {
            await _watchList.MarckAsWatched(Id);
            return Ok();
        }
        [HttpGet("GetWatchList")]
        public async Task<ActionResult> GetWatchList(int userId)
        {
            return Ok(await _watchList.GetWatchList(userId));
        }
        
    }
}
