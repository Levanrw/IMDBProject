using IMDB.DAL.Entities;
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
        private readonly IIMDBService _IMDBService;
        private readonly IEmailService _emailService;

        public JobSchedulerService(IWatchListRepository watchListRepository, INotificationsRepository notificationsRepository, IIMDBService iIMDBService, IEmailService emailService)
        {
            _watchListRepository = watchListRepository;
            _notificationsRepository = notificationsRepository;
            _IMDBService = iIMDBService;
            _emailService = emailService;
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
                        Poster = await _IMDBService.GetPoster(movie.MovieId);
                        MovieDescription = await _IMDBService.GetWikipediaData(movie.MovieId);
                    }
                    MoviesDetailInfo Info = new MoviesDetailInfo(movie.Id, movie.Title, movie.IMDBRating, Poster, MovieDescription,userId);
                    return Info;

                }
                else return null;
            }
            else return null;
        }
        public async Task SendNotification()
        {
            var MoviesDetail =await GetMoviesDetail(100);            
            if (MoviesDetail != null)
            {
                string BodyText = _emailService.GenerateEmailBody(MoviesDetail);
                _emailService.SendMail("shanavalevani@gmail.com", BodyText);
                Notifications row = new Notifications(MoviesDetail.UserId, MoviesDetail.Id, DateTime.Now);
               await _notificationsRepository.AddNotification(row);
            }

        }
    }
}
