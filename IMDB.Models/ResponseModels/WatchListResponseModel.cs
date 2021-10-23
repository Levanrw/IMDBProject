using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.ResponseModels
{
   public class WatchListResponseModel
    {
        public WatchListResponseModel()
        {
        }

        public WatchListResponseModel(int id,string movieId, string title, decimal? iMDBRating, string watched)
        {
            MovieId = movieId;
            Title = title;
            IMDBRating = iMDBRating;
            Watched = watched;
            Id = id;
        }
        public int Id { get; set; }
        public string MovieId { get; set; }
        public string Title { get; set; }
        public decimal? IMDBRating { get; set; }
        public string Watched { get; set; }

    }
}
