
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
                    mail.To.Add("shanavalevani@gmail.com");
                    mail.Subject = "Hello World";
                    mail.Body = "<h1>Hello123</h1>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("imdbspace@gmail.com", "shanava123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
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
