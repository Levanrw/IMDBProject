using IMDB.Models;
using IMDB.Models.RequestModels;
using IMDB.Service.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Services
{
  public  class IMDBService: IIMDBService
    {
        private readonly IExternalServiceCaller _externalServiceCaller;

        public IMDBService(IExternalServiceCaller externalServiceCaller)
        {
            _externalServiceCaller = externalServiceCaller;
        }

        public async Task<SearchResponseModel> SearchMovie(SearchMovieModel request)
        {
            var model = new ApiRequestModel(request.Lang, "Search", request.MovieName);
            var Result=await _externalServiceCaller.GetAsync(model);
            SearchResponseModel searchResponse = JsonConvert.DeserializeObject<SearchResponseModel>(Result);
            return searchResponse;
        }

        public async Task<decimal> GetMovieRating(string movieId)
        {
            var model = new ApiRequestModel(Models.Eenums.Language.Default, "Title", movieId);
            var Result = await _externalServiceCaller.GetAsync(model);
            var obj = JObject.Parse(Result);
            if (obj != null)
            {
                var Rating = obj["imDbRating"].ToString();
                return Rating == null ? 0 : Convert.ToDecimal(Rating);
            }
            else
                return 0;
        }
        public async Task<string> GetPoster(string movieId)
        {
            var model = new ApiRequestModel(Models.Eenums.Language.Default, "Posters", movieId);
            var Result = await _externalServiceCaller.GetAsync(model);
            var obj = JObject.Parse(Result);
            if (obj != null)
            {
                var Poster = obj["posters"][0]["link"].ToString();
                return Poster;
            }
            else
                return "";
        }
        public async Task<string> GetWikipediaData(string movieId)
        {
            var model = new ApiRequestModel(Models.Eenums.Language.Default, "Wikipedia", movieId);
            var Result = await _externalServiceCaller.GetAsync(model);
            var obj = JObject.Parse(Result);
            if (obj != null)
            {
                var Description = obj["plotFull"]["html"].ToString();
                return Description;
            }
            else
                return "";
        }
    }
}
