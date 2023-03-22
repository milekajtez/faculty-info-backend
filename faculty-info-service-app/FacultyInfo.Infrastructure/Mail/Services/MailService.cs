using FacultyInfo.Domain.Abstractions.Mail.Services;
using Microsoft.Extensions.Configuration;

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
            // sendgrid implementation
        }
    }
}
