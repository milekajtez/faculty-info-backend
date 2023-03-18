using AutoMapper;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Application.Syncs.Commands.RegisterMainAdmin;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.MainAdmin;
using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using Microsoft.Extensions.Configuration;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;

namespace FacultyInfo.Application.UnitTests.Syncs.Commands.RegisterMainAdmin
{
    public class RegisterMainAdminCommandHandlerUnitTests
    {
        private readonly RegisterMainAdminCommandHandler _registerMainAdminCommandHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IHashService> _hashServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public RegisterMainAdminCommandHandlerUnitTests() 
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _configurationMock = new Mock<IConfiguration>();
            _hashServiceMock = new Mock<IHashService>();
            _mapperMock = new Mock<IMapper>();

            _registerMainAdminCommandHandler = new RegisterMainAdminCommandHandler(
                _unitOfWorkMock.Object,
                _configurationMock.Object,
                _hashServiceMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowAlreadyExistsException_WhenMainAdminExists() 
        {
            // Arrange
            var registerMainAdminCommand = new RegisterMainAdminCommand();
            var security = new List<Security>()
            {
                new Security() 
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    Email = "Main Admin Test Email",
                    Password = "08DDC6C1884B225A61B600B1FC650488",
                    UserType = UserType.MainAdmin
                }
            }.AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.SecurityQuery.Find(It.IsAny<Expression<Func<Security, bool>>>()))
                .Returns(security);

            // Act & Assert
            await Assert.ThrowsAsync<AlreadyExistsException>(() =>
                _registerMainAdminCommandHandler.Handle(registerMainAdminCommand, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_RegisterMainAdmin_WhenEverythingWorks()
        {
            // Arrange
            var registerMainAdminCommand = new RegisterMainAdminCommand();
            var passwordValue = "Main Admin Test Password";
            var passwordHash = "08DDC6C1884B225A61B600B1FC650488";
            var security = new List<Security>().AsQueryable().BuildMock();

            var createdMainAdmin = new MainAdmin()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Email = "Main Admin Test Email",
                FirstName = "Main Admin Test FirstName",
                LastName = "Main Admin Test LastName"
            };

            var createdSecurity = new Security() 
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Email = createdMainAdmin.Email,
                Password = passwordHash
            };

            var mainAdminDto = new MainAdminDto() 
            {
                Id = createdMainAdmin.Id,
                Created = createdMainAdmin.Created,
                Updated = createdMainAdmin.Updated,
                Email = createdMainAdmin.Email,
                FirstName = createdMainAdmin.FirstName,
                LastName = createdMainAdmin.LastName,
            };

            _configurationMock.Setup(e => e["MAIN_ADMIN_EMAIL"])
                .Returns(createdMainAdmin.Email);
            _unitOfWorkMock.Setup(e => e.SecurityQuery.Find(It.IsAny<Expression<Func<Security, bool>>>()))
                .Returns(security);
            _configurationMock.Setup(e => e["MAIN_ADMIN_FIRST_NAME"])
                .Returns(createdMainAdmin.FirstName);
            _configurationMock.Setup(e => e["MAIN_ADMIN_LAST_NAME"])
                .Returns(createdMainAdmin.LastName);
            _configurationMock.Setup(e => e["MAIN_ADMIN_PASSWORD"])
                .Returns(passwordValue);
            _hashServiceMock.Setup(e => e.ConvertStringToHash(It.IsAny<string>()))
                .Returns(passwordHash);
            _unitOfWorkMock.Setup(e => e.MainAdminRepository.CreateAsync(It.IsAny<MainAdmin>()))
                .ReturnsAsync(createdMainAdmin);
            _unitOfWorkMock.Setup(e => e.SecurityRepository.CreateAsync(It.IsAny<Security>()))
                .ReturnsAsync(createdSecurity);
            _mapperMock.Setup(e => e.Map<MainAdminDto>(It.IsAny<MainAdmin>()))
                .Returns(mainAdminDto);

            // Act
            var result = await _registerMainAdminCommandHandler.Handle(registerMainAdminCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mainAdminDto.Id, result.Id);
            Assert.Equal(mainAdminDto.Created, result.Created);
            Assert.Equal(mainAdminDto.Updated, result.Updated);
            Assert.Equal(mainAdminDto.Email, result.Email);
            Assert.Equal(mainAdminDto.FirstName, result.FirstName);
            Assert.Equal(mainAdminDto.LastName, result.LastName);
            Assert.Equal(createdSecurity.Email, result.Email);
            Assert.Equal(createdSecurity.Password, passwordHash);
        }
    }
}
