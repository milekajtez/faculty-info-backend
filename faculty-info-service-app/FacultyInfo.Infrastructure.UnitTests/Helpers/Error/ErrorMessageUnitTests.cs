using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Infrastructure.Helper.Error;

namespace FacultyInfo.Infrastructure.UnitTests.Helpers.Error
{
    public class ErrorMessageUnitTests
    {
        #region GenerateErrorMessage
        [Theory]
        [InlineData(ErrorMessageType.UnknownEmailType)]
        public void GenerateErrorMessage_LoadSpecificMessage_WhenEverythingWorks_Infrastructure(ErrorMessageType errorMessageType)
        {
            // Arrange

            // Act
            var result = ErrorMessage.GenerateErrorMessage(errorMessageType);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(0, result.Length);
        }

        [Fact]
        public void GenerateErrorMessage_ReturnEmptyString_WhenErrorMessageTypeIsUnknown_Infrastrucutre()
        {
            // Arrange
            ErrorMessageType errorMessageType = (ErrorMessageType)(-1);

            // Act
            var result = ErrorMessage.GenerateErrorMessage(errorMessageType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Length);
        }
        #endregion
    }
}
