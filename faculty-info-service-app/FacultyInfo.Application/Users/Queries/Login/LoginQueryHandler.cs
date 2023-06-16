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

            switch (request.UserType) 
            {
                case UserType.MainAdmin:
                    var mainAdmin = await _unitOfWork.MainAdminQuery
                        .Find(e => e.Email == request.Email && e.Password == passwordHash)
                        .FirstOrDefaultAsync(cancellationToken) 
                        ?? IncorrectLogin(request.Email, request.Password);
                    break;
                case UserType.FacultyAdmin:
                    var facultyAdmin = await _unitOfWork.FacultyAdminQuery
                        .Find(e => e.Email == request.Email && e.Password == passwordHash)
                        .FirstOrDefaultAsync(cancellationToken)
                        ?? IncorrectLogin(request.Email, request.Password);
                    break;
                default:
                    throw new InvalidUserTypeException(
                         ErrorMessage.GenerateErrorMessage(ErrorMessageType.InvalidUserType, Array.Empty<string>()));
            }
            
            return _hashService.GenerateToken(
                request.Email,
                TypesConverterService.ConvertFromUserTypeToString(request.UserType));
        }

        private static object IncorrectLogin(string email, string password) 
        {
            throw new AuthentificationException(
                   ErrorMessage.GenerateErrorMessage(ErrorMessageType.IncorrectEmailOrPassword, new string[2] { email, password }));
        }
    }
}
