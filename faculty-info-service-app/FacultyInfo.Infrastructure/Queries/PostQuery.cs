using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class PostQuery : BaseQuery<Post>, IPostQuery
    {
        public PostQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
