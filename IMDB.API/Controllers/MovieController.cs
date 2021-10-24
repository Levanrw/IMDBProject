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
    public class MovieController : ControllerBase
    {
        private readonly IIMDBService _IMDBService;

        public MovieController(IIMDBService iMDBService)
        {
            _IMDBService = iMDBService;
        }
        [HttpGet("SearchMovie")]
        public async Task<IActionResult> SearchMovie([FromQuery]SearchMovieModel request)
        {
            return Ok(await _IMDBService.SearchMovie(request));
        }
       
    }
}
