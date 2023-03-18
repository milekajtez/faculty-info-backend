using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Application.Users.Queries.Login;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;

namespace FacultyInfo.Application.UnitTests.Users.Queries.Login
{
    public class LoginQueryHandlerUnitTests
    {
        private readonly LoginQueryHandler _loginQueryHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IHashService> _hashServiceMock;
        private const string Email = "test@email.test";
        private const string Password = "This is test password";
        private const string PasswordHash = "08DDC6C1884B225A61B600B1FC650488";

        public LoginQueryHandlerUnitTests() 
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _hashServiceMock = new Mock<IHashService>();

            _loginQueryHandler = new LoginQueryHandler(
                _unitOfWorkMock.Object,
                _hashServiceMock.Object);
        }

        [Fact]
        public async Task Handle_Login_WhenEverythingWorks() 
        {
            // Arrange
            var loginQuery = new LoginQuery(Email, Password);
            var token = "This is test token";

            var security = new List<Security>() 
            {
                new Security()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Email = Email,
                    UserType = UserType.MainAdmin,
                    Password = PasswordHash
                }
            }.AsQueryable().BuildMock();

            _hashServiceMock.Setup(e => e.ConvertStringToHash(It.IsAny<string>()))
                .Returns(PasswordHash);
            _unitOfWorkMock.Setup(e => e.SecurityQuery.Find(It.IsAny<Expression<Func<Security, bool>>>()))
                .Returns(security);
            _hashServiceMock.Setup(e => e.GenerateToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(token);

            // Act
            var result = await _loginQueryHandler.Handle(loginQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(token, result);
        }

        [Fact]
        public async Task Handle_ThrowAuthentificationException_WhenCredentailsAreNotValid()
        {
            // Arrange
            var loginQuery = new LoginQuery(Email, Password);
            var security = new List<Security>() { }.AsQueryable().BuildMock();

            _hashServiceMock.Setup(e => e.ConvertStringToHash(It.IsAny<string>()))
                .Returns(PasswordHash);
            _unitOfWorkMock.Setup(e => e.SecurityQuery.Find(It.IsAny<Expression<Func<Security, bool>>>()))
                .Returns(security);

            // Act & Assert
            await Assert.ThrowsAsync<AuthentificationException>(() =>
                _loginQueryHandler.Handle(loginQuery, CancellationToken.None));
        }
    }
}
