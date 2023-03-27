using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Mail;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace FacultyInfo.Infrastructure.Mail.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly ISendGridClient _sendGridClient;

        public MailService(IConfiguration configuration, ISendGridClient sendGridClient) 
        {
            _configuration = configuration;
            _sendGridClient = sendGridClient;
        }

        public async Task<MailResponse> SendAsync(string receiverMail, string firstName, string lastName, string tempPassword)
        {
            var templateData = new
            {
                firstName,
                lastName,
                tempPassword,
                buttonLink = _configuration["CORS_ORIGINS"]
            };

            var mailRequest = new MailRequest(
                _configuration["SENDGRID_TEMPLATE_USER_REGISTRATION"],
                receiverMail,
                templateData,
                _configuration["APPLICATION_NAME"]);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_configuration["SENDER_EMAIL"], mailRequest.SenderName),
            };

            msg.SetTemplateId(mailRequest.TemplateId);
            msg.SetTemplateData(mailRequest.TemplateData);
            msg.AddTo(new EmailAddress(mailRequest.Receiver));

            var response = await _sendGridClient.SendEmailAsync(msg);

            if (response.IsSuccessStatusCode) return new MailResponse(HttpStatusCode.OK, "Successfully sent");
            
            return new MailResponse(response.StatusCode, "Something went wrong");
        }
    }
}
