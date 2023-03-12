using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class CourseSubjectsQuery : BaseQuery<CourseSubjects>, ICourseSubjectsQuery
    {
        public CourseSubjectsQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
