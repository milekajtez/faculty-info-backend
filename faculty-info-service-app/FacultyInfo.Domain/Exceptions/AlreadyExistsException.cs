using System.Net;

namespace FacultyInfo.Domain.Exceptions
{
    public class AlreadyExistsException : BaseException
    {
        public AlreadyExistsException(string message)
            : base(message, HttpStatusCode.Conflict) { }
    }
}
