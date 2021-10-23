using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.ResponseModels
{
   public class MoviesDetailInfo
    {
        public MoviesDetailInfo(string title, decimal? rating, string poster, string description)
        {
            Title = title;
            Rating = rating;
            Poster = poster;
            Description = description;
        }

        public string Title { get; set; }
        public decimal? Rating { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
    }
}
