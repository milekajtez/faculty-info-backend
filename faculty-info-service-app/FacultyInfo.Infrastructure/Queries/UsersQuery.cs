using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class UsersQuery : BaseQuery<User>, IUsersQuery
    {
        public UsersQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
