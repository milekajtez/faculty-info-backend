using FacultyInfo.Application.Helpers.Converters;
using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Exceptions;

namespace FacultyInfo.Application.UnitTests.Helpers.Converters
{
    public class TypesConverterServiceUnitTests
    {
        #region ConvertFromUserTypeToString
        [Theory]
        [InlineData(UserType.MainAdmin)]
        [InlineData(UserType.FacultyAdmin)]
        [InlineData(UserType.Professor)]
        [InlineData(UserType.Student)]
        public void ConvertFromUserTypeToString_UserTypeConversion_WhenEverythingWorks(UserType userType) 
        {
            // Arrange
            var userTypeString =
                userType == UserType.MainAdmin ? "Main admin" :
                userType == UserType.FacultyAdmin ? "Faculty admin" :
                userType == UserType.Professor ? "Professor" :
                userType == UserType.Student ? "Student" : "";

            // Act
            var result = TypesConverterService.ConvertFromUserTypeToString(userType);

            // Assert
            Assert.Equal(userTypeString, result);
        }

        [Fact]
        public void ConvertFromUserTypeToString_ThrowInvalidConversionException_WhenUserTypeIsInvalid()
        {
            // Arrange
            UserType userType = (UserType)(-1);

            // Act & Assert
            Assert.Throws<InvalidConversionException>(() =>
                TypesConverterService.ConvertFromUserTypeToString(userType));
        }
        #endregion
    }
}
