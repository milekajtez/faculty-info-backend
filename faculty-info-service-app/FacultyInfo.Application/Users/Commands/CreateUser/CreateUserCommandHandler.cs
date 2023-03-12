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
            // string errorMessage = $"User with Username: {request.Username} or Email: {request.Email} already exist";

            return new UserDto();
        }
    }
}
