using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class CourseStudentsQuery : BaseQuery<CourseStudents>, ICourseStudentsQuery
    {
        public CourseStudentsQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
