using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.ResponseModels
{
    public class MovieInfo
    {
        public MovieInfo()
        {
        }

        public MovieInfo(decimal? rating, string title, string description)
        {
            Rating = rating;
            Title = title;
            Description = description;
        }

        public decimal? Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
