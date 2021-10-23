using IMDB.DAL.Entities;
using IMDB.Models.RequestModels;
using IMDB.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.DAL.Interface
{
   public interface IWatchListRepository
    {
        public Task AddWatchList(WatchList watchList);
        public Task MarkAsWatched(int Id);
        public Task<IEnumerable<WatchList>> GetWatchList(int userId);
    }
}
