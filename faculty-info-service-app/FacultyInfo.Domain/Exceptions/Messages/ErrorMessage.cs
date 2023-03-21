using FacultyInfo.Domain.Enums.ErrorMessage;

namespace FacultyInfo.Domain.Exceptions.Messages
{
    public class ErrorMessage
    {
        public static string GenerateErrorMessage(ErrorMessageType errorMessageType, string[] data) 
        {
            return errorMessageType switch
            {
                ErrorMessageType.MainAdminHasBeenFound => $"Main admin already exists",
                ErrorMessageType.FacultyAdminHasBeenFound => $"Faculty admin already exists",
                ErrorMessageType.InvalidConversionFromUserTypeToString => $"Invalid user type",
                ErrorMessageType.IncorrectEmailOrPassword => $"User with username: '{data[0]}' and password: '{data[1]}' doesn't exist",
                ErrorMessageType.ConversionToHashInvalid => $"The minimum length of the string for conversion to hash value is 1",
                _ => string.Empty,
            };
        }
    }
}
