using System.Net;

namespace FacultyInfo.Domain.Exceptions
{
    public class UnknownEmailTypeException : BaseException
    {
        public UnknownEmailTypeException(string message) :
            base(message, HttpStatusCode.InternalServerError)
        { }
    }
}
