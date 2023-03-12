using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class SubjectProfessorsQuery : BaseQuery<SubjectProfessors>, ISubjectProfessorsQuery
    {
        public SubjectProfessorsQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
