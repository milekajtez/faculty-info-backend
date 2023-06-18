using FacultyInfo.Application.Helpers.Converters;
using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.Users.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashService _hashService;

        public LoginQueryHandler(IUnitOfWork unitOfWork, IHashService hashService)
        {
            _unitOfWork = unitOfWork;
            _hashService = hashService;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var passwordHash = _hashService.ConvertStringToHash(request.Password);

            var mainAdmin = await _unitOfWork.MainAdminQuery
                .Find(e => e.Email == request.Email && e.Password == passwordHash)
                .FirstOrDefaultAsync(cancellationToken);

            if (mainAdmin is not null)
                return _hashService.GenerateToken(
                    request.Email,
                    TypesConverterService.ConvertFromUserTypeToString(UserType.MainAdmin));

            var facultyAdmin = await _unitOfWork.FacultyAdminQuery
                .Find(e => e.Email == request.Email && e.Password == passwordHash)
                .FirstOrDefaultAsync(cancellationToken);

            if (facultyAdmin is not null)
                return _hashService.GenerateToken(
                    request.Email,
                    TypesConverterService.ConvertFromUserTypeToString(UserType.FacultyAdmin));

            throw new AuthentificationException(
                   ErrorMessage.GenerateErrorMessage(ErrorMessageType.IncorrectEmailOrPassword, new string[2] { request.Email, request.Password }));
        }
    }
}
