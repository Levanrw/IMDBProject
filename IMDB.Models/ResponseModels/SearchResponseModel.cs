using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models
{
  public  class SearchResponseModel
    {
        //public SearchResponseModel(string searchType, string expression,  results result)
        //{
        //    this.searchType = searchType;
        //    this.expression = expression ;
        //    this.result = result ;
        //}

        public string searchType { get; set; }
        public string expression { get; set; }
        public Results[] results { get; set; }

    }
    public class Results
    {
        public string id { get; set; }
        public string resultType { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
