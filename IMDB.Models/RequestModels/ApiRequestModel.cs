using IMDB.Models.Eenums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.RequestModels
{
  public  class ApiRequestModel
    {
        public ApiRequestModel(Language lang, string keyWord, string expression)
        {
            Lang = lang;
            KeyWord = keyWord;
            Expression = expression;
        }

        public Language Lang { get; set; }
        public string KeyWord { get; set; }
        public string Expression { get; set; }
    }
}
