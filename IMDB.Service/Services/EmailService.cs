
using IMDB.Models.ResponseModels;
using IMDB.Service.Interface;
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
        public void SendMail(string emailAddress, string body)
        {
            try
            {
              
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("imdbspace@gmail.com");
                    mail.To.Add(emailAddress);
                    mail.Subject = "Movie Suggest";
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("imdbspace@gmail.com", "shanava123");
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
