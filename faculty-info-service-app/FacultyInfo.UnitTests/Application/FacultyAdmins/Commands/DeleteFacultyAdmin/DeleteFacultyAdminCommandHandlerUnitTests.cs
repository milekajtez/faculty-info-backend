using FacultyInfo.Application.FacultyAdmins.Commands.DeleteFacultyAdmin;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MediatR;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;

namespace FacultyInfo.Application.UnitTests.FacultyAdmins.Commands.DeleteFacultyAdmin
{
    public class DeleteFacultyAdminCommandHandlerUnitTests
    {
        private readonly DeleteFacultyAdminCommandHandler _deleteFacultyAdminCommandHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMailService> _mailServiceMock;

        public DeleteFacultyAdminCommandHandlerUnitTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mailServiceMock = new Mock<IMailService>();

            _deleteFacultyAdminCommandHandler = new DeleteFacultyAdminCommandHandler(
                _unitOfWorkMock.Object,
                _mailServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowNotFoundException_WhenFacultyAdminDoesntExist()
        {
            // Arrange
            var deleteFacultyAdminCommand = new DeleteFacultyAdminCommand(Guid.NewGuid());
            var facultyAdmin = new List<FacultyAdmin>().AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmin);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _deleteFacultyAdminCommandHandler.Handle(deleteFacultyAdminCommand, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_DeleteFacultyAdmin_WhenEverythingWorks()
        {
            // Arrange
            var deleteFacultyAdminCommand = new DeleteFacultyAdminCommand(Guid.NewGuid());
            var facultyAdmin = new List<FacultyAdmin>()
            {
                new FacultyAdmin()
                {
                    Id = deleteFacultyAdminCommand.FacultyAdminId
                }
            }.AsQueryable().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmin);
            _unitOfWorkMock.Setup(e => e.FacultyAdminRepository.Delete(It.IsAny<FacultyAdmin>()));

            // Act
            var result = await _deleteFacultyAdminCommandHandler.Handle(deleteFacultyAdminCommand, CancellationToken.None);

            // Assert
            Assert.Equal(Unit.Value, result);
        }
    }
}
