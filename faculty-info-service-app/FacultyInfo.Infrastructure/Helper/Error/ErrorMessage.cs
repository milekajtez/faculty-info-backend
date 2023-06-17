using FacultyInfo.Domain.Enums.ErrorMessage;

namespace FacultyInfo.Infrastructure.Helper.Error
{
    public class ErrorMessage
    {
        public static string GenerateErrorMessage(ErrorMessageType errorMessageType)
        {
            return errorMessageType switch
            {
                ErrorMessageType.UnknownEmailType => "Unknown user type.",
                _ => string.Empty,
            };
        }
    }
}
