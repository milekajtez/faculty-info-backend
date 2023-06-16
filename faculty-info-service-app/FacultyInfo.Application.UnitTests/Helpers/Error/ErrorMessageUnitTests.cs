using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Domain.Enums.ErrorMessage;

namespace FacultyInfo.Application.UnitTests.Helpers.Error
{
    public class ErrorMessageUnitTests
    {
        #region GenerateErrorMessage
        [Theory]
        [InlineData(ErrorMessageType.MainAdminHasBeenFound)]
        [InlineData(ErrorMessageType.FacultyAdminHasBeenFound)]
        [InlineData(ErrorMessageType.FacultyHasBeenFound)]
        [InlineData(ErrorMessageType.InvalidConversionFromUserTypeToString)]
        [InlineData(ErrorMessageType.IncorrectEmailOrPassword)]
        [InlineData(ErrorMessageType.ConversionToHashInvalid)]
        [InlineData(ErrorMessageType.FacultyHasNotFound)]
        [InlineData(ErrorMessageType.FacultyAdminHasNotFound)]
        [InlineData(ErrorMessageType.InvalidUserType)]
        public void GenerateErrorMessage_LoadSpecificMessage_WhenEverythingWorks(ErrorMessageType errorMessageType) 
        {
            // Arrange
            var data = GetData(errorMessageType).ToArray();

            // Act
            var result = ErrorMessage.GenerateErrorMessage(errorMessageType, data);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(0, result.Length);
        }

        [Fact]
        public void GenerateErrorMessage_ReturnEmptyString_WhenErrorMessageTypeIsUnknown()
        {
            // Arrange
            ErrorMessageType errorMessageType = (ErrorMessageType)(-1);
            var data = GetData(errorMessageType).ToArray();

            // Act
            var result = ErrorMessage.GenerateErrorMessage(errorMessageType, data);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Length);
        }

        private static List<string> GetData(ErrorMessageType errorMessageType) 
        {
            return errorMessageType switch
            {
                ErrorMessageType.MainAdminHasBeenFound => new List<string>(),
                ErrorMessageType.FacultyAdminHasBeenFound => new List<string>(),
                ErrorMessageType.FacultyHasBeenFound => new List<string>() { Guid.NewGuid().ToString() },
                ErrorMessageType.InvalidConversionFromUserTypeToString => new List<string>(),
                ErrorMessageType.IncorrectEmailOrPassword => new List<string>() { Guid.NewGuid().ToString(), "Test password" },
                ErrorMessageType.ConversionToHashInvalid => new List<string>(),
                ErrorMessageType.FacultyHasNotFound => new List<string>() { Guid.NewGuid().ToString() },
                ErrorMessageType.FacultyAdminHasNotFound => new List<string>() { Guid.NewGuid().ToString() },
                ErrorMessageType.InvalidUserType => new List<string>(),
                _ => new List<string>(),
            };
        }
        #endregion
    }
}
