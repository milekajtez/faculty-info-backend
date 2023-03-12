using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class FacultyAdminRepository : BaseRepository<FacultyAdmin>, IFacultyAdminRepository
    {
        public FacultyAdminRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
