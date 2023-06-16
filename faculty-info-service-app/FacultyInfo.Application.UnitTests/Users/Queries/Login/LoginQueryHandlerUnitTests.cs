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

        [Theory]
        [InlineData(UserType.MainAdmin)]
        [InlineData(UserType.FacultyAdmin)]
        public async Task Handle_Login_WhenEverythingWorks(UserType userType) 
        {
            // Arrange
            var loginQuery = new LoginQuery(Email, Password, userType);
            var token = "This is test token";

            var mainAdmin = new List<MainAdmin>() 
            {
                new MainAdmin()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Email = Email,
                    Password = PasswordHash
                }
            }.AsQueryable().BuildMock();

            var facultyAdmin = new List<FacultyAdmin>()
            {
                new FacultyAdmin()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Email = Email,
                    Password = PasswordHash
                }
            }.AsQueryable().BuildMock();

            _hashServiceMock.Setup(e => e.ConvertStringToHash(It.IsAny<string>()))
                .Returns(PasswordHash);
            _unitOfWorkMock.Setup(e => e.MainAdminQuery.Find(It.IsAny<Expression<Func<MainAdmin, bool>>>()))
                .Returns(mainAdmin);
            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmin);
            _hashServiceMock.Setup(e => e.GenerateToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(token);

            // Act
            var result = await _loginQueryHandler.Handle(loginQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(token, result);
        }

        [Theory]
        [InlineData(UserType.MainAdmin)]
        [InlineData(UserType.FacultyAdmin)]
        public async Task Handle_ThrowAuthentificationException_WhenCredentailsAreNotValid(UserType userType)
        {
            // Arrange
            var loginQuery = new LoginQuery(Email, Password, userType);
            var mainAdmin = new List<MainAdmin>().AsQueryable().BuildMock();
            var facultyAdmin = new List<FacultyAdmin>().AsQueryable().BuildMock();

            _hashServiceMock.Setup(e => e.ConvertStringToHash(It.IsAny<string>()))
                .Returns(PasswordHash);
            _unitOfWorkMock.Setup(e => e.MainAdminQuery.Find(It.IsAny<Expression<Func<MainAdmin, bool>>>()))
                .Returns(mainAdmin);
            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmin);

            // Act & Assert
            await Assert.ThrowsAsync<AuthentificationException>(() =>
                _loginQueryHandler.Handle(loginQuery, CancellationToken.None));
        }
    }
}
