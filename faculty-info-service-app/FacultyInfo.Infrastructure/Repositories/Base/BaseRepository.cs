using FacultyInfo.Domain.Abstractions.Repositories.Base;
using FacultyInfo.Infrastructure.Context;
using System.Linq.Expressions;

namespace FacultyInfo.Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dataContext.Set<T>()
                .Where(expression);
        }
    }
}
