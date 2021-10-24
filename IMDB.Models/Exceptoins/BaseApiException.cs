using IMDB.Models.Eenums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace IMDB.Models.Exceptoins
{
    public class BaseApiException : Exception
    {
        public int ResponseHttpStatusCode { get; }

        public string BackEndMessage { get; protected set; }
        public bool ExceptionIsLogged { get; set; }

        public BaseApiException(HttpStatusCode responseHttpStatusCode)
        {
            ResponseHttpStatusCode = (int)responseHttpStatusCode;
        }

        public BaseApiException(HttpStatusCode responseHttpStatusCode, string backEndMessage, Language lang) : base($"{(lang == Language.GE ? "დაფიქსირდა შეცდომა" : "An error has occurred")}")
        {
            ResponseHttpStatusCode = (int)responseHttpStatusCode;
            BackEndMessage = backEndMessage;
        }

        public BaseApiException(HttpStatusCode responseHttpStatusCode, string message) : base(message)
        {
            ResponseHttpStatusCode = (int)responseHttpStatusCode;
            BackEndMessage = message;
        }
    }
}
