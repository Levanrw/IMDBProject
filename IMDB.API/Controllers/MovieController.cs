using IMDB.Models;
using IMDB.Models.RequestModels;
using IMDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IMDB.API.Controllers
{
    /// <summary>
/// 
/// </summary>
    [ApiController]
    
    [Route("[controller]")]
    
    public class MovieController : ControllerBase
    {
        private readonly IIMDBService _IMDBService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMDBService"></param>
        public MovieController(IIMDBService iMDBService)
        {
            _IMDBService = iMDBService;
        }

        /// <summary>
        ///Search Movie By Name 
        ///</summary>
        /// <param name="request">Search Model</param>
        /// <returns>Method return movies list</returns>

        [HttpGet("SearchMovie")]
        
        public async Task<IActionResult> SearchMovie([FromQuery]SearchMovieModel request)
        {
            return Ok(await _IMDBService.SearchMovie(request));
        }
       
    }
}
