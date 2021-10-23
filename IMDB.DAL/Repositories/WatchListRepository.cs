using IMDB.DAL.Entities;
using IMDB.DAL.Interface;
using IMDB.Models.RequestModels;
using IMDB.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.DAL.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {

        public async Task AddWatchList(WatchList watchList)
        {
            using (var _context = new IMDBDBContext())
            {

                await _context.WatchList.AddAsync(watchList);
                await _context.SaveChangesAsync();
            }
        }
        public async Task MarkAsWatched(int Id)
        {
            using (var _context = new IMDBDBContext())
            {
                var row = _context.WatchList.FirstOrDefault(item => item.Id == Id);
                if (row != null)
                {
                    row.Watched = true;
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<IEnumerable<WatchList>> GetWatchList(int userId)
        {
            List<WatchList> list = new List<WatchList>();
            using (var _context = new IMDBDBContext())
            {
                var row = _context.WatchList.Where(s => s.UserId == userId).ToList();
                foreach (var item in row)
                {
                    list.Add(new WatchList(item.UserId, item.MovieId, item.Title,item.Description, item.IMDBRating, item.Watched ));

                }
                return list;
            }
        }
    }
}
