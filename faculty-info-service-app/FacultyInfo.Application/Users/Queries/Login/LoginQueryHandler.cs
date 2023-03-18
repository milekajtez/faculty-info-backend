using FacultyInfo.Application.Helpers.Converters;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Exceptions.Messages;
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

            var security = await _unitOfWork.SecurityQuery
                .Find(e => e.Email == request.Email && e.Password == passwordHash)
                .FirstOrDefaultAsync(cancellationToken);

            if (security is null)
                throw new AuthentificationException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.IncorrectEmailOrPassword, 
                    new string[2] { request.Email, request.Password }));

            return _hashService.GenerateToken(
                security.Email,
                TypesConverterService.ConvertFromUserTypeToString(security.UserType));
        }
    }
}
