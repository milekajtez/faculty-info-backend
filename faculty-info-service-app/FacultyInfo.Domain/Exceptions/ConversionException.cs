using System.Net;

namespace FacultyInfo.Domain.Exceptions
{
    public class ConversionException : BaseException
    {
        public ConversionException(string message)
            : base(message, HttpStatusCode.InternalServerError) { }
    }
}
