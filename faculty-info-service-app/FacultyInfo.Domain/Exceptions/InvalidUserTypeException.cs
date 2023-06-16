using System.Net;

namespace FacultyInfo.Domain.Exceptions
{
    public class InvalidUserTypeException : BaseException
    {
        public InvalidUserTypeException(string message) :
            base(message, HttpStatusCode.InternalServerError)
        { }
    }
}
