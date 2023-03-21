using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Moq;

namespace FacultyInfo.Application.UnitTests.Helpers.Hash
{
    public class HashServiceUnitTests
    {
        private readonly HashService _hashService;
        private readonly Mock<IConfiguration> _configurationMock;
        
        public HashServiceUnitTests() 
        {
            _configurationMock = new Mock<IConfiguration>();

            _hashService = new HashService(_configurationMock.Object);
        }

        #region ConvertStringToHash
        [Fact]
        public void ConvertStringToHash_ConvertSuccessfully_WhenEverythingWorks() 
        {
            // Arrange
            var text = "Test text";
            var hashMethod = "SHA-256";
            var textResult = "ab0e2c4143f4f6815306af9c90bcc21a06ce5a7c8d365af5ec15d5aa515fdbc1";

            _configurationMock.Setup(e => e["HASH_METHOD"])
                .Returns(hashMethod);

            // Act
            var result = _hashService.ConvertStringToHash(text);

            // Assert
            Assert.Equal(textResult, result);
        }

        [Fact]
        public void ConvertStringToHash_ThrowConversionException_WhenTextValueIsEmptyString()
        {
            // Arrange
            string text = string.Empty;

            // Act & Assert
            Assert.Throws<ConversionException>(() =>
                _hashService.ConvertStringToHash(text));
        }
        #endregion
        #region GenerateToken
        [Fact]
        public void GenerateToken_MakeNewToken_WhenEverythingWorks() 
        {
            // Arrange
            var email = "test@email.test";
            var userRole = "Main Admin";
            var jwtKey = "Qwertyuiopasdfghjklz";
            var jwtIssuer = "Test jwt issuer";
            var jwtAudience = "Test jwt audience";
            var sessionLength = "1";

            _configurationMock.Setup(e => e["JWT_KEY"])
                .Returns(jwtKey);
            _configurationMock.Setup(e => e["JWT_ISSUER"])
                .Returns(jwtIssuer);
            _configurationMock.Setup(e => e["JWT_AUDIENCE"])
                .Returns(jwtAudience);
            _configurationMock.Setup(e => e["SESSION_LENGTH_MINUTES"])
                .Returns(sessionLength);

            // Act
            var result = _hashService.GenerateToken(email, userRole);

            // Assert
            Assert.True(result.Length > 0);
        }
        #endregion
    }
}
