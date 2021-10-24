using IMDB.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Interface
{
   public interface IJobSchedulerService
    {
        public Task<MoviesDetailInfo> GetMoviesDetail(int userId);
        public Task SendNotification();
    }
}
