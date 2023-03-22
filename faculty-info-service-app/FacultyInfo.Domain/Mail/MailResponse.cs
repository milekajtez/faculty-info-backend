using System.Net;

namespace FacultyInfo.Domain.Mail
{
    public class MailResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public MailResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
