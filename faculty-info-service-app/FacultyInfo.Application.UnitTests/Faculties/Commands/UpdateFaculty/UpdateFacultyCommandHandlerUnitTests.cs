using AutoMapper;
using FacultyInfo.Application.Faculties.Commands.UpdateFaculty;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.Faculty;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;

namespace FacultyInfo.Application.UnitTests.Faculties.Commands.UpdateFaculty
{
    public class UpdateFacultyCommandHandlerUnitTests
    {
        private readonly UpdateFacultyCommandHandler _updateFacultyCommandHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private const string Tin = "1234567890";
        private const string Description = "Description test";
        private const string Location = "Location test";
        private const string Name = "Name test";

        public UpdateFacultyCommandHandlerUnitTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _updateFacultyCommandHandler = new UpdateFacultyCommandHandler(
                _unitOfWorkMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowNotFoundException_WhenFacultyDoesntExist()
        {
            // Arrange
            var updateFacultyCommand = new UpdateFacultyCommand()
            {
                Id = Guid.NewGuid(),
                Tin = Tin,
                Description = Description,
                Location = Location,
                Name = Name
            };

            var faculty = new List<Faculty>().AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyRepository.Find(It.IsAny<Expression<Func<Faculty, bool>>>()))
                .Returns(faculty);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _updateFacultyCommandHandler.Handle(updateFacultyCommand, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_UpdateFaculty_WhenEverythingWorks()
        {
            // Arrange
            var updateFacultyCommand = new UpdateFacultyCommand()
            {
                Id = Guid.NewGuid(),
                Tin = Tin,
                Description = null,
                Location = Location,
                Name = Name
            };

            var faculty = new List<Faculty>() 
            {
                new Faculty()
                {
                    Id = Guid.NewGuid(),
                    Tin = Tin,
                    Description = null,
                    Location = Location,
                    Name = Name
                }
                
            }.AsQueryable().BuildMock();

            var facultyDto = new FacultyDto()
            {
                Id = updateFacultyCommand.Id,
                Tin = updateFacultyCommand.Tin,
                Description = updateFacultyCommand.Description,
                Location = updateFacultyCommand.Location,
                Name = updateFacultyCommand.Name
            };

            _unitOfWorkMock.Setup(e => e.FacultyRepository.Find(It.IsAny<Expression<Func<Faculty, bool>>>()))
                .Returns(faculty);
            _mapperMock.Setup(e => e.Map<FacultyDto>(It.IsAny<Faculty>()))
                .Returns(facultyDto);

            // Act
            var result = await _updateFacultyCommandHandler.Handle(updateFacultyCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updateFacultyCommand.Id, result.Id);
            Assert.Equal(updateFacultyCommand.Tin, result.Tin);
            Assert.Null(result.Description);
            Assert.Equal(updateFacultyCommand.Location, result.Location);
            Assert.Equal(updateFacultyCommand.Name, result.Name);
        }
    }
}
