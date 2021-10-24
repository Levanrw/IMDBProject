using IMDB.Models.RequestModels;
using IMDB.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Interface
{
  public  interface IWatchList
    {
        public Task AddWatchList(WatchListRequest request);
        public Task MarckAsWatched(int Id);
        public Task<IEnumerable<WatchListResponseModel>> GetWatchList(int userId);
    }
}
