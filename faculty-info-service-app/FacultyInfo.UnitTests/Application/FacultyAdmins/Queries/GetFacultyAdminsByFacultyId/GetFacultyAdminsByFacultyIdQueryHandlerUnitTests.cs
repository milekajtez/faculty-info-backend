using AutoMapper;
using FacultyInfo.Application.FacultyAdmins.Queries.GetFacultyAdmins;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;

namespace FacultyInfo.Application.UnitTests.FacultyAdmins.Queries.GetFacultyAdminsByFacultyId
{
    public class GetFacultyAdminsByFacultyIdQueryHandlerUnitTests
    {
        private readonly GetFacultyAdminsByFacultyIdQueryHandler _getFacultyAdminsByFacultyIdQueryHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;

        public GetFacultyAdminsByFacultyIdQueryHandlerUnitTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _getFacultyAdminsByFacultyIdQueryHandler = new GetFacultyAdminsByFacultyIdQueryHandler(
                _unitOfWorkMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowNotFoundException_WhenFacultyAdminDoesntExist()
        {
            // Arrange
            var getFacultyAdminsByFacultyIdQuery = new GetFacultyAdminsByFacultyIdQuery(Guid.NewGuid());
            var facultyAdmins = new List<FacultyAdmin>().BuildMock();

            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmins);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _getFacultyAdminsByFacultyIdQueryHandler.Handle(getFacultyAdminsByFacultyIdQuery, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ReturnFacultyAdminsByFacultyId_WhenFacultyAdminExist()
        {
            // Arrange
            var getFacultyAdminsByFacultyIdQuery = new GetFacultyAdminsByFacultyIdQuery(Guid.NewGuid());
            var facultyAdmins = new List<FacultyAdmin>() 
            {
                new FacultyAdmin()
                {
                    Id = Guid.NewGuid(),
                    FacultyId = getFacultyAdminsByFacultyIdQuery.FacultyId
                },
                new FacultyAdmin()
                {
                    Id = Guid.NewGuid(),
                    FacultyId = getFacultyAdminsByFacultyIdQuery.FacultyId
                }
            }.BuildMock();

            var facultyAdminsDtos = new List<FacultyAdminDto>()
            {
                new FacultyAdminDto()
                {
                    Id = Guid.NewGuid(),
                    FacultyId = getFacultyAdminsByFacultyIdQuery.FacultyId
                },
                new FacultyAdminDto()
                {
                    Id = Guid.NewGuid(),
                    FacultyId = getFacultyAdminsByFacultyIdQuery.FacultyId
                }
            };

            _unitOfWorkMock.Setup(e => e.FacultyAdminQuery.Find(It.IsAny<Expression<Func<FacultyAdmin, bool>>>()))
                .Returns(facultyAdmins);
            _mapperMock.Setup(e => e.Map<List<FacultyAdminDto>>(It.IsAny<List<FacultyAdmin>>()))
                .Returns(facultyAdminsDtos);

            // Act
            var result = await _getFacultyAdminsByFacultyIdQueryHandler.Handle(
                getFacultyAdminsByFacultyIdQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(facultyAdmins.Count(), result.Count());
            Assert.Contains(result, e => e.FacultyId == getFacultyAdminsByFacultyIdQuery.FacultyId);
        }
    }
}
