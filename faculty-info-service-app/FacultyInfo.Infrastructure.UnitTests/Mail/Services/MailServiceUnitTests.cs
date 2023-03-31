using FacultyInfo.Domain.Mail;
using FacultyInfo.Infrastructure.Mail.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace FacultyInfo.Infrastructure.UnitTests.Mail.Services
{
    public class MailServiceUnitTests
    {
        private readonly MailService _mailService;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<ISendGridClient> _sendGridClientMock;
        private const string ButtonLink = "Test button link";
        private const string SendgridTemplateUserReg = "Test sendgrid template id";
        private const string ApplicationName = "Faculty Info App";
        private const string Email = "test@gmail.com";
        private const string FirstName = "Test first name";
        private const string LastName = "Test last name";
        private const string TempPassword = "Test temp password";

        public MailServiceUnitTests() 
        {
            _configurationMock = new Mock<IConfiguration>();
            _sendGridClientMock = new Mock<ISendGridClient>();

            _mailService = new MailService(_configurationMock.Object, _sendGridClientMock.Object);
        }

        [Fact]
        public async Task SendAsync_SendEmailRequestToSendGrid_WhenEverythingWorks() 
        {
            // Arrange
            var response = new Response(HttpStatusCode.OK, null, null);

            _configurationMock.Setup(e => e["CORS_ORIGINS"])
                .Returns(ButtonLink);
            _configurationMock.Setup(e => e["SENDGRID_TEMPLATE_USER_REGISTRATION"])
                .Returns(SendgridTemplateUserReg);
            _configurationMock.Setup(e => e["APPLICATION_NAME"])
                .Returns(ApplicationName);
            _configurationMock.Setup(e => e["SENDER_EMAIL"])
                .Returns(Email);
            _sendGridClientMock.Setup(e => e.SendEmailAsync(It.IsAny<SendGridMessage>(), CancellationToken.None))
                .ReturnsAsync(response);

            // Act
            var result = await _mailService.SendAsync(Email, FirstName, LastName, TempPassword);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task SendAsync_ShouldntSendEmal_WhenSendgridDoesntWork()
        {
            // Arrange
            var response = new Response(HttpStatusCode.InternalServerError, null, null);

            _configurationMock.Setup(e => e["CORS_ORIGINS"])
                .Returns(ButtonLink);
            _configurationMock.Setup(e => e["SENDGRID_TEMPLATE_USER_REGISTRATION"])
                .Returns(SendgridTemplateUserReg);
            _configurationMock.Setup(e => e["APPLICATION_NAME"])
                .Returns(ApplicationName);
            _configurationMock.Setup(e => e["SENDER_EMAIL"])
                .Returns(Email);
            _sendGridClientMock.Setup(e => e.SendEmailAsync(It.IsAny<SendGridMessage>(), CancellationToken.None))
                .ReturnsAsync(response);

            // Act
            var result = await _mailService.SendAsync(Email, FirstName, LastName, TempPassword);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
