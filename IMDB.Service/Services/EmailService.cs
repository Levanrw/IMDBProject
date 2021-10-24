
using IMDB.Models.ResponseModels;
using IMDB.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendMail(string emailAddress, string body)
        {
            try
            {
                var r = _config["ConnectionStrings:IMDBConnection"];

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_config["EmailConfiguration:From:Email"]);
                    mail.To.Add(emailAddress);
                    mail.Subject = "Movie Suggest";
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com",Convert.ToInt32(_config["EmailConfiguration:From:Port"])))
                    {
                        smtp.Credentials = new NetworkCredential(_config["EmailConfiguration:From:Email"], _config["EmailConfiguration:From:Password"]);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        public string GenerateEmailBody(MoviesDetailInfo body)
        {
            string BodyString = $"<html> <head> <title>Suggest Movie</title></head>" +
                 $"<body><table><tr><td><b>{body.Title}</b></td></tr>" +
                 $"<br/><br/><tr><td><b>IMDB Rating:   <b/> <b style='color:red'>{body.Rating}</b></td></tr>" +
                 $"<br/><br/><br/><br/><br/><br/><tr><td>{body.Description}</td></tr>" +
                 $"<br/><br/><tr><td><img src={body.Poster} width='400px' height='550px'></td></tr>" +
                 $"</head></html>";
            return BodyString;

        }

    }
}
