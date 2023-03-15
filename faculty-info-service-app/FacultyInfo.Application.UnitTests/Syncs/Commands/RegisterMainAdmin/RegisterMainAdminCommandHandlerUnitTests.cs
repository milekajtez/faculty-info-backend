using AutoMapper;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Application.Syncs.Commands.RegisterMainAdmin;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.MainAdmin;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using Microsoft.Extensions.Configuration;
using Moq;

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

            _unitOfWorkMock.Setup(e => e.MainAdminQuery.CountAsync())
                .ReturnsAsync(1);

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
            var mainAdminData = new MainAdmin()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                UserName = "Main Admin Test Username",
                Email = "Main Admin Test Email",
                FirstName = "Main Admin Test FirstName",
                LastName = "Main Admin Test LastName",
                PasswordValue = "08DDC6C1884B225A61B600B1FC650488"
            };

            var mainAdminDto = new MainAdminDto() 
            {
                Id = mainAdminData.Id,
                Created = mainAdminData.Created,
                Updated = mainAdminData.Updated,
                UserName = mainAdminData.UserName,
                Email = mainAdminData.Email,
                FirstName = mainAdminData.FirstName,
                LastName = mainAdminData.LastName,
            };

            _unitOfWorkMock.Setup(e => e.MainAdminQuery.CountAsync())
                .ReturnsAsync(0);
            _configurationMock.Setup(e => e["MAIN_ADMIN_USERNAME"])
                .Returns(mainAdminData.UserName);
            _configurationMock.Setup(e => e["MAIN_ADMIN_EMAIL"])
                .Returns(mainAdminData.Email);
            _configurationMock.Setup(e => e["MAIN_ADMIN_FIRST_NAME"])
                .Returns(mainAdminData.FirstName);
            _configurationMock.Setup(e => e["MAIN_ADMIN_LAST_NAME"])
                .Returns(mainAdminData.LastName);
            _configurationMock.Setup(e => e["MAIN_ADMIN_PASSWORD"])
                .Returns(passwordValue);
            _hashServiceMock.Setup(e => e.ConvertStringToHash(It.IsAny<string>()))
                .Returns(mainAdminData.PasswordValue);
            _unitOfWorkMock.Setup(e => e.MainAdminRepository.CreateAsync(It.IsAny<MainAdmin>()))
                .ReturnsAsync(mainAdminData);
            _mapperMock.Setup(e => e.Map<MainAdminDto>(It.IsAny<MainAdmin>()))
                .Returns(mainAdminDto);

            // Act
            var result = await _registerMainAdminCommandHandler.Handle(registerMainAdminCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mainAdminDto.Id, result.Id);
            Assert.Equal(mainAdminDto.Created, result.Created);
            Assert.Equal(mainAdminDto.Updated, result.Updated);
            Assert.Equal(mainAdminDto.UserName, result.UserName);
            Assert.Equal(mainAdminDto.Email, result.Email);
            Assert.Equal(mainAdminDto.FirstName, result.FirstName);
            Assert.Equal(mainAdminDto.LastName, result.LastName);
        }
    }
}
