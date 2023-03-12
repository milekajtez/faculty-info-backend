using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class MainAdminRepository : BaseRepository<MainAdmin>, IMainAdminRepository
    {
        public MainAdminRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
