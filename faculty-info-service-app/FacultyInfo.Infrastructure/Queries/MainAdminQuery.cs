using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class MainAdminQuery : BaseQuery<MainAdmin>, IMainAdminQuery
    {
        public MainAdminQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
