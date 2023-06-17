using FacultyInfo.Domain.Enums.Email;
using FacultyInfo.Domain.Mail;

namespace FacultyInfo.Domain.Abstractions.Mail.Services
{
    public interface IMailService
    {
        Task<MailResponse> SendAsync(EmailType emailType, string receiverMail, object templateData);
        // Task<MailResponse> SendAsync(string receiverMail, string firstName, string lastName);
    }
}
