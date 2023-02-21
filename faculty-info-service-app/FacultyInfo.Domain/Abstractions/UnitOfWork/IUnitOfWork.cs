using FacultyInfo.Domain.Abstractions.Queries;
using FacultyInfo.Domain.Abstractions.Repositories;

namespace FacultyInfo.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Queries
        IUsersQuery UsersQuery { get; }
        #endregion
        #region Repositories
        IUsersRepository UsersRepository { get; }
        #endregion

        Task<int> CompleteAsync();
    }
}
