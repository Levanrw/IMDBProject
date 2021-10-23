using IMDB.DAL.Interface;
using IMDB.DAL.Repositories;
using IMDB.Models.ResponseModels;
using IMDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Services
{
   public class JobSchedulerService: IJobSchedulerService
    {
        private readonly IWatchListRepository _watchListRepository;
        private readonly INotificationsRepository _notificationsRepository;
        private readonly IIMDBService _iIMDBService;

        public JobSchedulerService(IWatchListRepository watchListRepository, INotificationsRepository notificationsRepository, IIMDBService iIMDBService)
        {
            _watchListRepository = watchListRepository;
            _notificationsRepository = notificationsRepository;
            _iIMDBService = iIMDBService;
        }
        public async Task<MoviesDetailInfo> GetMoviesDetail(int userId)
        {
            var watchlist= await _watchListRepository.GetWatchList(userId);
            if (watchlist != null)
            {
                int wathListCount = watchlist.Where(t => t.Watched == false).Count();
                string Poster="",MovieDescription="";

                WatchListResponseModel movie;
                if (wathListCount > 2)
                {
                    var row = watchlist.Where(w => w.Watched == false).OrderBy(t => t.IMDBRating).FirstOrDefault();
                    movie = new WatchListResponseModel(row.Id,row.MovieId, row.Title, row.IMDBRating, row.Watched == true ? "Watched" : "Not watched");
                    DateTime? NotificationDate = _notificationsRepository.GetLastNotificationDate(movie.Id);
                    if (NotificationDate != null && (DateTime.Now - NotificationDate.Value).TotalDays > 30)
                    {
                        Poster = await _iIMDBService.GetPoster(movie.MovieId);
                        MovieDescription = await _iIMDBService.GetWikipediaData(movie.MovieId);
                    }
                    MoviesDetailInfo Info = new MoviesDetailInfo(movie.Title, movie.IMDBRating, Poster, MovieDescription);
                    return Info;

                }
                else return null;
            }
            else return null;
        }
    }
}
