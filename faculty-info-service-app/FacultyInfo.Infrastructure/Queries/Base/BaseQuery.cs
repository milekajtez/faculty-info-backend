using FacultyInfo.Domain.Abstractions.Queries.Base;
using FacultyInfo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FacultyInfo.Infrastructure.Queries.Base
{
    public class BaseQuery<T> : IBaseQuery<T> where T : class
    {
        protected DataContext _dataContext;
        public BaseQuery(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dataContext.Set<T>()
                .AnyAsync(expression, cancellationToken);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dataContext.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>()
                .AsNoTracking();
        }
        
        public async Task<int> CountAsync() 
        {
            return await _dataContext.Set<T>().CountAsync();
        }
    }
}
