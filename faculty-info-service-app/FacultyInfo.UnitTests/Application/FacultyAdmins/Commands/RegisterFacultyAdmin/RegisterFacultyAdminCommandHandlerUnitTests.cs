using AutoMapper;
using FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using Microsoft.Extensions.Configuration;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;

namespace FacultyInfo.Application.UnitTests.FacultyAdmins.Commands.RegisterFacultyAdmin
{
    public class RegisterFacultyAdminCommandHandlerUnitTests
    {
        private readonly RegisterFacultyAdminCommandHandler _registerFacultyAdminCommandHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IHashService> _hashServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMailService> _mailServiceMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private const string Email = "test@email.test";
        private const string FirstName = "Faculty Admin Test FirstName";
        private const string LastName = "Faculty Admin Test LastName";

        public RegisterFacultyAdminCommandHandlerUnitTests() 
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _hashServiceMock = new Mock<IHashService>();
            _mapperMock = new Mock<IMapper>();
            _mailServiceMock = new Mock<IMailService>();
            _configurationMock = new Mock<IConfiguration>();

            _registerFacultyAdminCommandHandler = new RegisterFacultyAdminCommandHandler(
                _unitOfWorkMock.Object,
                _hashServiceMock.Object,
                _mapperMock.Object,
                _mailServiceMock.Object,
                _configurationMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowAlreadyExistsException_WhenFacultyAdminExists()
        {
            // Arrange
            var registerFacultyAdminCommand = new RegisterFacultyAdminCommand();
            var facultyAdmin = new List<FacultyAdmin>()
            {
                new FacultyAdmin()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName
                }
            }.AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmin);

            // Act & Assert
            await Assert.ThrowsAsync<AlreadyExistsException>(() =>
                _registerFacultyAdminCommandHandler.Handle(registerFacultyAdminCommand, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_RegisterMainAdmin_WhenEverythingWorks()
        {
            // Arrange
            var registerFacultyAdminCommand = new RegisterFacultyAdminCommand();
            var passwordValue = "Faculty Admin Test Password";
            var passwordHash = "08DDC6C1884B225A61B600B1FC650488";
            var cors_origins = "http://localhost:3000";
            var facultyAdmin = new List<FacultyAdmin>().AsQueryable().BuildMock();

            var createdFacultyAdmin = new FacultyAdmin()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName
            };

            var facultyAdminDto = new FacultyAdminDto()
            {
                Id = createdFacultyAdmin.Id,
                Created = createdFacultyAdmin.Created,
                Updated = createdFacultyAdmin.Updated,
                Email = createdFacultyAdmin.Email,
                FirstName = createdFacultyAdmin.FirstName,
                LastName = createdFacultyAdmin.LastName,
            };

            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmin);
            _hashServiceMock.Setup(e => e.GenerateTempPassword())
                .Returns(passwordValue);
            _hashServiceMock.Setup(e => e.ConvertStringToHash(It.IsAny<string>()))
                .Returns(passwordHash);
            _configurationMock.Setup(e => e["CORS_ORIGINS"])
                .Returns(cors_origins);
            _unitOfWorkMock.Setup(e => e.FacultyAdminRepository.CreateAsync(It.IsAny<FacultyAdmin>()))
               .ReturnsAsync(createdFacultyAdmin);
            _mapperMock.Setup(e => e.Map<FacultyAdminDto>(It.IsAny<FacultyAdmin>()))
                .Returns(facultyAdminDto);

            // Act
            var result = await _registerFacultyAdminCommandHandler.Handle(registerFacultyAdminCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(facultyAdminDto.Id, result.Id);
            Assert.Equal(facultyAdminDto.Created, result.Created);
            Assert.Equal(facultyAdminDto.Updated, result.Updated);
            Assert.Equal(facultyAdminDto.Email, result.Email);
            Assert.Equal(facultyAdminDto.FirstName, result.FirstName);
            Assert.Equal(facultyAdminDto.LastName, result.LastName);
        }
    }
}
