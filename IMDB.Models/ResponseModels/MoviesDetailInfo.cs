using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.ResponseModels
{
   public class MoviesDetailInfo
    {
        public MoviesDetailInfo(int id,string title, decimal? rating, string poster, string description,int userId)
        {
            Title = title;
            Rating = rating;
            Poster = poster;
            Description = description;
            Id = id;
            UserId = userId;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Rating { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
