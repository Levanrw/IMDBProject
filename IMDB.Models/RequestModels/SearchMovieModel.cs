using IMDB.Models.Eenums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.RequestModels
{
   public class SearchMovieModel
    {       
        public string MovieName { get; set; }
        public Language Lang { get; set; }

    }
}
