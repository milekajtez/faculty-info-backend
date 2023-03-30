using AutoMapper;
using FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
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

        public RegisterFacultyAdminCommandHandlerUnitTests() 
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _hashServiceMock = new Mock<IHashService>();
            _mapperMock = new Mock<IMapper>();
            _mailServiceMock = new Mock<IMailService>();

            _registerFacultyAdminCommandHandler = new RegisterFacultyAdminCommandHandler(
                _unitOfWorkMock.Object,
                _hashServiceMock.Object,
                _mapperMock.Object,
                _mailServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowAlreadyExistsException_WhenFacultyAdminExists()
        {
            // Arrange
            var registerFacultyAdminCommand = new RegisterFacultyAdminCommand();
            var security = new List<Security>()
            {
                new Security()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    Email = "Faculty Admin Test Email",
                    Password = "08DDC6C1884B225A61B600B1FC650488",
                    UserType = UserType.FacultyAdmin
                }
            }.AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.SecurityQuery.Find(It.IsAny<Expression<Func<Security, bool>>>()))
                .Returns(security);

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
            var security = new List<Security>().AsQueryable().BuildMock();

            var createdFacultyAdmin = new FacultyAdmin()
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
                Email = createdFacultyAdmin.Email,
                Password = passwordHash
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

            _unitOfWorkMock.Setup(e => e.SecurityQuery.Find(It.IsAny<Expression<Func<Security, bool>>>()))
                .Returns(security);
            _hashServiceMock.Setup(e => e.GenerateTempPassword())
                .Returns(passwordValue);
            _hashServiceMock.Setup(e => e.ConvertStringToHash(It.IsAny<string>()))
                .Returns(passwordHash);
            _unitOfWorkMock.Setup(e => e.FacultyAdminRepository.CreateAsync(It.IsAny<FacultyAdmin>()))
               .ReturnsAsync(createdFacultyAdmin);
            _unitOfWorkMock.Setup(e => e.SecurityRepository.CreateAsync(It.IsAny<Security>()))
                .ReturnsAsync(createdSecurity);
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
            Assert.Equal(createdSecurity.Email, result.Email);
            Assert.Equal(createdSecurity.Password, passwordHash);
        }
    }
}
