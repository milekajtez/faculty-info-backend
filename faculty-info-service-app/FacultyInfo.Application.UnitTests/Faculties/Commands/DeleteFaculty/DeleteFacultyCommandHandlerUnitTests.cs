using FacultyInfo.Application.Faculties.Commands.DeleteFaculty;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MediatR;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;

namespace FacultyInfo.Application.UnitTests.Faculties.Commands.DeleteFaculty
{
    public class DeleteFacultyCommandHandlerUnitTests
    {
        private readonly DeleteFacultyCommandHandler _deleteFacultyCommandHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMailService> _mailServiceMock;

        public DeleteFacultyCommandHandlerUnitTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mailServiceMock = new Mock<IMailService>();

            _deleteFacultyCommandHandler = new DeleteFacultyCommandHandler(
                _unitOfWorkMock.Object,
                _mailServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowNotFoundException_WhenFacultyDoesntExist() 
        {
            // Arrange
            var deleteFacultyCommand = new DeleteFacultyCommand(Guid.NewGuid());
            var faculty = new List<Faculty>().AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyQuery.Find(It.IsAny<Expression<Func<Faculty, bool>>>()))
                .Returns(faculty);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _deleteFacultyCommandHandler.Handle(deleteFacultyCommand, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_DeleteFaculty_WhenEverythingWorks()
        {
            // Arrange
            var deleteFacultyCommand = new DeleteFacultyCommand(Guid.NewGuid());
            var faculty = new List<Faculty>() 
            { 
                new Faculty()
                {
                    Id = deleteFacultyCommand.FacultyId
                } 
            }.AsQueryable().BuildMock();

            var facultyAdmin = new List<FacultyAdmin>()
            {
                new FacultyAdmin()
                {
                    Id = Guid.NewGuid(),
                    FacultyId = deleteFacultyCommand.FacultyId
                }
            }.AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyQuery.Find(It.IsAny<Expression<Func<Faculty, bool>>>()))
                .Returns(faculty);
            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmin);
            _unitOfWorkMock.Setup(e => e.FacultyRepository.Delete(It.IsAny<Faculty>()));

            // Act
            var result = await _deleteFacultyCommandHandler.Handle(deleteFacultyCommand, CancellationToken.None);

            // Assert
            Assert.Equal(Unit.Value, result);
        }
    }
}
