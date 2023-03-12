using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class LikeQuery : BaseQuery<Like>, ILikeQuery
    {
        public LikeQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
