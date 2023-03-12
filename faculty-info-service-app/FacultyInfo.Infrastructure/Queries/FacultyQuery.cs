using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class FacultyQuery : BaseQuery<Faculty>, IFacultyQuery
    {
        public FacultyQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
