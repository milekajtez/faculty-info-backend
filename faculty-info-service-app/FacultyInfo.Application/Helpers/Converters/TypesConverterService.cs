using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Exceptions.Messages;

namespace FacultyInfo.Application.Helpers.Converters
{
    public class TypesConverterService
    {
        public static string ConvertFromUserTypeToString(UserType userType) 
        {
            return userType switch
            {
                UserType.MainAdmin => "Main admin",
                UserType.FacultyAdmin => "Faculty admin",
                UserType.Professor => "Professor",
                UserType.Student => "Student",
                _ => throw new InvalidConversionException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.InvalidConversionFromUserTypeToString, Array.Empty<string>())),
            };
        }
    }
}
