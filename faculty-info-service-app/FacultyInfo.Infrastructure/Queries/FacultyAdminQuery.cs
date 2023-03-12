using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class FacultyAdminQuery : BaseQuery<FacultyAdmin>, IFacultyAdminQuery
    {
        public FacultyAdminQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
