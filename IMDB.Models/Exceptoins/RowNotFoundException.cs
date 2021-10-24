using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Models.Exceptoins
{
    public class RowNotFoundException : BaseApiException
    {
        public RowNotFoundException() : base(System.Net.HttpStatusCode.NotFound)
        {
            Message = "Row by this Id not found!";

        }
        public override string Message { get; }
    }
}
