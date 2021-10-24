using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.Exceptoins
{
    public class MovieNotFoundException : BaseApiException
    {
        public MovieNotFoundException() : base(System.Net.HttpStatusCode.NotFound)
        {
            Message = "Movie like this key not found!";

        }
        public override string Message { get; }
    }
}
