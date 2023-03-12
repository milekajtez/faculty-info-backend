using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
