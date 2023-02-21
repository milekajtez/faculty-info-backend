using System.Net;

namespace FacultyInfo.Domain.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) :
            base(message, HttpStatusCode.NotFound)
        { }
    }
}
