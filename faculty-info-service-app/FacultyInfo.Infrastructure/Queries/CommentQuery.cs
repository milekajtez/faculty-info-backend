using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class CommentQuery : BaseQuery<Comment>, ICommentQuery
    {
        public CommentQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
