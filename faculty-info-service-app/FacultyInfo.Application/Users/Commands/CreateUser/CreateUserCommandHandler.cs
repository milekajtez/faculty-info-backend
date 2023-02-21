using AutoMapper;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.User;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MediatR;

namespace FacultyInfo.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public CreateUserCommandHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IHashService hashService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string errorMessage = $"User with Username: {request.Username} or Email: {request.Email} already exist";

            var userExists = await _unitOfWork.UsersQuery
                .AnyAsync(da => da.UserName == request.Username || da.Email == request.Email, cancellationToken);

            if (userExists) throw new AlreadyExistsException($"User with Username: {request.Username} or Email: {request.Email} already exist");

            string passwordHash = _hashService.GetStringToHash(request.Password);
            User newUser = _mapper.Map<User>(request);

            // generate token
            string token = "";

            // add user to table
            // add password to table

            var result = new UserDto();
            result.Init(newUser.Id, newUser.UserName, token);

            return result;
        }
    }
}
