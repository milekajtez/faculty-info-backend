using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries.Base;

namespace FacultyInfo.Infrastructure.Queries
{
    public class AttachmentQuery : BaseQuery<Attachment>, IAttachmentQuery
    {
        public AttachmentQuery(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
