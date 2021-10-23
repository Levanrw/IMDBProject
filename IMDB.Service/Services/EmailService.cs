
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
                var fromAddress = new MailAddress("imdbspace@gmail.com", "From Name");
                var toAddress = new MailAddress("shanavalevani@gmail.com", "To Name");
                const string fromPassword = "shanava123";
                const string subject = "Subject";
                const string body1 = "Body";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 25,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }


                //SmtpClient client = new SmtpClient("smtp.gmail.com", 5354);
                //client.EnableSsl = true;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Credentials = new NetworkCredential("imdbspace@gmail.com", "shanava123");
                //MailMessage msgobj = new MailMessage();
                //msgobj.To.Add("shanavalevani@gmail.com");
                //msgobj.From = new MailAddress("imdbspace@gmail.com");
                //msgobj.Subject = "CreditInfo Result";
                //msgobj.Body = "Bodyy";
                //client.Send(msgobj);

            }
            catch (Exception ex)
            {

            }
        }
    }
}
