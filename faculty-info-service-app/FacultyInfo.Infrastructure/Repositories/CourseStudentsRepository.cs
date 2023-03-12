using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class CourseStudentsRepository : BaseRepository<CourseStudents>, ICourseStudentsRepository
    {
        public CourseStudentsRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
