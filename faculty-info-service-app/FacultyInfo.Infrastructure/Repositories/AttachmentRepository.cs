using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
