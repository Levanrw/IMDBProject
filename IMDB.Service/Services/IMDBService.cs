using IMDB.Models;
using IMDB.Models.Exceptoins;
using IMDB.Models.RequestModels;
using IMDB.Models.ResponseModels;
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
            try
            {
                var model = new ApiRequestModel(request.Lang, "Search", request.MovieName);
                var Result = await _externalServiceCaller.GetAsync(model);
                if (Result == null)
                {
                    throw new MovieNotFoundException();
                }
                SearchResponseModel searchResponse = JsonConvert.DeserializeObject<SearchResponseModel>(Result);
                return searchResponse;
            }
            catch (Exception ex)
            {
                throw  new Exception(ex.Message);
            }
        }

        public async Task<MovieInfo> GetMovieInfo(string movieId)
        {
            try
            {
                var model = new ApiRequestModel(Models.Eenums.Language.Default, "Title", movieId);
                var Result = await _externalServiceCaller.GetAsync(model);
                var obj = JObject.Parse(Result);
                if (obj != null)
                {
                    var Rating = obj["imDbRating"].ToString();
                    string Title = obj["title"].ToString();
                    string Description = obj["plot"].ToString();
                    decimal? ParsedRating = 0;
                    if (Rating!=null && Rating!="" )
                    {
                        ParsedRating =Convert.ToDecimal(Rating);
                    }
                    var movie = new MovieInfo(ParsedRating, Title, Description);
                    return movie;
                }
                else
                    return new MovieInfo();
            }
            catch (Exception ex)
            {
                return new MovieInfo();
            }
        }
        public async Task<string> GetPoster(string movieId)
        {
            try
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
            catch (Exception ex)
            {
                return "";
            }
        }
        public async Task<string> GetWikipediaData(string movieId)
        {
            try
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
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
