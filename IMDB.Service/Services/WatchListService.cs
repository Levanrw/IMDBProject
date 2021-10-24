using Hangfire;
using IMDB.DAL.Interface;
using IMDB.Models.RequestModels;
using IMDB.Models.ResponseModels;
using IMDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Services
{
    public class WatchListService : IWatchList
    {
        private readonly IWatchListRepository _watchListRepository;
        private readonly IIMDBService _iMDBService;

        public WatchListService(IWatchListRepository watchListRepository, IIMDBService iMDBService = null)
        {
            _watchListRepository = watchListRepository;
            _iMDBService = iMDBService;
        }
        public async Task AddWatchList(WatchListRequest request)
        {
            try
            {
                var  movie = await _iMDBService.GetMovieInfo(request.MovieId);
                var wachlist = new DAL.Entities.WatchList(0, 100, request.MovieId, movie.Title, movie.Description, movie.Rating, false);
                await _watchListRepository.AddWatchList(wachlist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task MarckAsWatched(int Id)
        {
           await _watchListRepository.MarkAsWatched(Id);
        }
        public async Task<IEnumerable<WatchListResponseModel>> GetWatchList(int userId)
        {
           
           var watchlist= await _watchListRepository.GetWatchList(userId);
            List<WatchListResponseModel> list = new List<WatchListResponseModel>();
            foreach (var item in watchlist)
            {
                list.Add(new WatchListResponseModel(item.Id, item.MovieId, item.Title, item.IMDBRating, item.Watched == false ? "Not watched" : "Watched"));
            }

            return list;
        }

      
    }
}
