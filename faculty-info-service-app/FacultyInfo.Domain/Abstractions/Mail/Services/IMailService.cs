namespace FacultyInfo.Domain.Abstractions.Mail.Services
{
    public interface IMailService
    {
        void SendEmail(string sendToEmail);
    }
}
