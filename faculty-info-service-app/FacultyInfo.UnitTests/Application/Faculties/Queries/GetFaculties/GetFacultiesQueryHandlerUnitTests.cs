using AutoMapper;
using FacultyInfo.Application.Faculties.Queries.GetFaculties;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.Faculty;
using FacultyInfo.Domain.Models;
using MockQueryable.Moq;
using Moq;

namespace FacultyInfo.Application.UnitTests.Faculties.Queries.GetFaculties
{
    public class GetFacultiesQueryHandlerUnitTests
    {
        private readonly GetFacultiesQueryHandler _getFacultiesQueryHandler;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;

        public GetFacultiesQueryHandlerUnitTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _getFacultiesQueryHandler = new GetFacultiesQueryHandler(
                _unitOfWorkMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnAllFaculties_WhenEverythingWorks()
        {
            // Arrange
            var getFacultiesQuery = new GetFacultiesQuery();
            var faculty = new List<Faculty>()
            {
                new Faculty()
                {
                    Tin = "1234567890"
                }
            }.AsQueryable().BuildMock();

            var facultyDto = new List<FacultyDto>()
            {
                new FacultyDto() 
                {
                    Tin = faculty.First().Tin,
                    Description = faculty.First().Description,
                    Location = faculty.First().Location,
                    Name = faculty.First().Name
                }
            };

            _unitOfWorkMock.Setup(e => e.FacultyQuery.GetAll())
                .Returns(faculty);
            _mapperMock.Setup(e => e.Map<List<FacultyDto>>(It.IsAny<List<Faculty>>()))
                .Returns(facultyDto);

            // Act
            var result = await _getFacultiesQueryHandler.Handle(getFacultiesQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(faculty.Count(), result.Count());
        }
    }
}
