using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Models;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Repositories.Base;

namespace FacultyInfo.Infrastructure.Repositories
{
    public class SubjectProfessorsRepository : BaseRepository<SubjectProfessors>, ISubjectProfessorsRepository
    {
        public SubjectProfessorsRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
