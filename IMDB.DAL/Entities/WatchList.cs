using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.DAL.Entities
{
   public class WatchList
    {
        public WatchList(int userId, string movieId, string title, string description, decimal? iMDBRating, bool watched)
        {
            UserId = userId;
            MovieId = movieId;
            Title = title;
            Description = description;
            IMDBRating = iMDBRating;
            Watched = watched;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? IMDBRating { get; set; }
        public bool Watched { get; set; }

    }
}
