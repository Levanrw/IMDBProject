using IMDB.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Interface
{
  public  interface IEmailService
    {
        public void SendMail(string emailAddress, string body);
        public string GenerateEmailBody(MoviesDetailInfo body);
    }
}
