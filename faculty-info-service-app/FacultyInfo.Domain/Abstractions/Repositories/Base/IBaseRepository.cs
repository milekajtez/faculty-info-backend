using System.Linq.Expressions;

namespace FacultyInfo.Domain.Abstractions.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
    }
}
