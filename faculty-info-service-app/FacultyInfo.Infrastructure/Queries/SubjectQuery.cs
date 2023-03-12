using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class SubjectQuery : BaseQuery<Subject>, ISubjectQuery
    {
        public SubjectQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
