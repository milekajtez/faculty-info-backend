using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
