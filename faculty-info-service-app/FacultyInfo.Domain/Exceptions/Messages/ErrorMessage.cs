using FacultyInfo.Domain.Enums.ErrorMessage;

namespace FacultyInfo.Domain.Exceptions.Messages
{
    public class ErrorMessage
    {
        public static string GenerateErrorMessage(ErrorMessageType errorMessageType, string[] data) 
        {
            return errorMessageType switch
            {
                ErrorMessageType.MainAdminHasBeenFound => $"Super admin already exists",
                _ => string.Empty,
            };
        }
    }
}
