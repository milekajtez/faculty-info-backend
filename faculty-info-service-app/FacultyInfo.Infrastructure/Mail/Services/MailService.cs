using FacultyInfo.Domain.Abstractions.Mail.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace FacultyInfo.Infrastructure.Mail.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public void SendEmail(string sendToEmail)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com")
                {
                    EnableSsl = true,
                    Port = 465,
                    Credentials = new NetworkCredential(_configuration["SENDER_EMAIL"], _configuration["SENDER_EMAIL_PASSWORD"])
                };

                var newMail = new MailMessage
                {
                    From = new MailAddress(_configuration["SENDER_EMAIL"], _configuration["SENDER_NAME"]),
                    Subject = _configuration["TEMP_PASSWORD_EMAIL_SUBJECT"],
                    IsBodyHtml = true,
                    Body = "<h1> This is my first Templated Email in C# </h1>"
                };

                newMail.To.Add(sendToEmail);

                client.Send(newMail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
