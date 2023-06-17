using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Enums.Email;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Mail;
using FacultyInfo.Infrastructure.Helper.Error;
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

        #region SendAsync
        public async Task<MailResponse> SendAsync(EmailType emailType, string receiverMail, object templateData)
        {
            var mailRequest = new MailRequest(
                GetEmailTemplate(emailType),
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
        #endregion

        #region GetEmailTemplate
        public string GetEmailTemplate(EmailType emailType) 
        {
            return emailType switch
            {
                EmailType.UserRegistration => _configuration["SENDGRID_TEMPLATE_USER_REGISTRATION"],
                EmailType.UserIsDeleted => _configuration["SENDGRID_TEMPLATE_USER_IS_DELETED"],
                _ => throw new UnknownEmailTypeException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.FacultyHasNotFound)),
            };
        }
        #endregion
    }
}
