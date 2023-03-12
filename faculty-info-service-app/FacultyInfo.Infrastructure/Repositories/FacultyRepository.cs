using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class FacultyRepository : BaseRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
