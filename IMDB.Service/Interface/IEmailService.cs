using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Interface
{
  public  interface IEmailService
    {
        public void SendMail(string emailAddress, string body);
    }
}
