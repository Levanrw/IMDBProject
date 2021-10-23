using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.RequestModels
{
   public class WatchListRequest
    {
        public string MovieId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
