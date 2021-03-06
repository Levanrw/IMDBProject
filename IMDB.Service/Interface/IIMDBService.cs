using IMDB.Models;
using IMDB.Models.RequestModels;
using IMDB.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Interface
{
   public interface IIMDBService
    {
        public  Task<SearchResponseModel> SearchMovie(SearchMovieModel request);
        public Task<MovieInfo> GetMovieInfo(string movieId);
        public Task<string> GetPoster(string movieId);
        public Task<string> GetWikipediaData(string movieId);
    }
}
