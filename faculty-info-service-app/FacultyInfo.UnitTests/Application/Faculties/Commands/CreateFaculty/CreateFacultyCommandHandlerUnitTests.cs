using AutoMapper;
using FacultyInfo.Application.Faculties.Commands.CreateFaculty;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.Faculty;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;

namespace FacultyInfo.Application.UnitTests.Faculties.Commands.CreateFaculty
{
    public class CreateFacultyCommandHandlerUnitTests
    {
        private readonly CreateFacultyCommandHandler _createFacultyCommandHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private const string FacultyTin = "1234567890";
        private const string FacultyDescription = "Test faculty description";
        private const string FacultyLocation = "Test faculty location";
        private const string FacultyName = "Test faculty name";

        public CreateFacultyCommandHandlerUnitTests() 
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _createFacultyCommandHandler = new CreateFacultyCommandHandler(
                _unitOfWorkMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowAlreadyExistsException_WhenFacultyExists()
        {
            // Arrange
            var createFacultyCommand = new CreateFacultyCommand() 
            {
                Tin = FacultyTin,
                Description = FacultyDescription,
                Location = FacultyLocation,
                Name = FacultyName
            };

            var faculty = new List<Faculty>()
            {
                new Faculty()
                {
                    Tin = createFacultyCommand.Tin
                }
            }.AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyQuery.Find(It.IsAny<Expression<Func<Faculty, bool>>>()))
                .Returns(faculty);

            // Act & Assert
            await Assert.ThrowsAsync<AlreadyExistsException>(() =>
                _createFacultyCommandHandler.Handle(createFacultyCommand, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_AddNewFaculty_WhenEverythingWorks()
        {
            // Arrange
            var createFacultyCommand = new CreateFacultyCommand()
            {
                Tin = FacultyTin,
                Description = FacultyDescription,
                Location = FacultyLocation,
                Name = FacultyName
            };

            var newFaculty = new Faculty()
            {
                Tin = FacultyTin,
                Description = FacultyDescription,
                Location = FacultyLocation,
                Name = FacultyName
            };

            var facultyDto = new FacultyDto()
            {
                Tin = FacultyTin,
                Description = FacultyDescription,
                Location = FacultyLocation,
                Name = FacultyName
            };

            var faculty = new List<Faculty>() { }.AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyQuery.Find(It.IsAny<Expression<Func<Faculty, bool>>>()))
                .Returns(faculty);
            _unitOfWorkMock.Setup(e => e.FacultyRepository.CreateAsync(It.IsAny<Faculty>()))
                .ReturnsAsync(newFaculty);
            _mapperMock.Setup(e => e.Map<FacultyDto>(It.IsAny<Faculty>()))
                .Returns(facultyDto);

            // Act
            var result = await _createFacultyCommandHandler.Handle(createFacultyCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createFacultyCommand.Tin, result.Tin);
            Assert.Equal(createFacultyCommand.Description, result.Description);
            Assert.Equal(createFacultyCommand.Location, result.Location);
            Assert.Equal(createFacultyCommand.Name, result.Name);
        }
    }
}
