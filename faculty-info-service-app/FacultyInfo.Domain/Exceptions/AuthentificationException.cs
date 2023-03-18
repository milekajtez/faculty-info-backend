using System.Net;

namespace FacultyInfo.Domain.Exceptions
{
    public class AuthentificationException : BaseException
    {
        public AuthentificationException(string message)
            : base(message, HttpStatusCode.Unauthorized) { }
    }
}
