using Newtonsoft.Json;

namespace FacultyInfo.Domain.Exceptions.Details
{
    public class ErrorDetails
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
