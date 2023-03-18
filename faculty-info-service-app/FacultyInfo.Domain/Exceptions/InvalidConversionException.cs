using System.Net;

namespace FacultyInfo.Domain.Exceptions
{
    public class InvalidConversionException : BaseException
    {
        public InvalidConversionException(string message)
            : base(message, HttpStatusCode.InternalServerError) { }
    }
}
