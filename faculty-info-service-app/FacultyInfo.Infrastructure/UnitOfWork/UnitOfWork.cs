using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Abstractions.Repositories;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Infrastructure.Context;
using FacultyInfo.Infrastructure.Queries;
using FacultyInfo.Infrastructure.Repositories;

namespace FacultyInfo.Infrastructure.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        #region Queries
        private IUsersQuery _usersQuery;
        #endregion
        #region Repositories
        private IUsersRepository _usersRepository;
        #endregion

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Queries
        public IUsersQuery UsersQuery => _usersQuery ??= new UsersQuery(_dataContext);
        #endregion
        #region Repositories
        public IUsersRepository UsersRepository => _usersRepository ??= new UsersRepository(_dataContext);
        #endregion

        public async Task<int> CompleteAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
