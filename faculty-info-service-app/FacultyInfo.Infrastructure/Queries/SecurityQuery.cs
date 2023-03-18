using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class SecurityQuery : BaseQuery<Security>, ISecurityQuery
    {
        public SecurityQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
