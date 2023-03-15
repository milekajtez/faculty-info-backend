using AutoMapper;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.MainAdmin;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Exceptions.Messages;
using FacultyInfo.Domain.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FacultyInfo.Application.Syncs.Commands.RegisterMainAdmin
{
    public class RegisterMainAdminCommandHandler : IRequestHandler<RegisterMainAdminCommand, MainAdminDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IHashService _hashService;
        private readonly IMapper _mapper;

        public RegisterMainAdminCommandHandler(
            IUnitOfWork unitOfWork, 
            IConfiguration configuration,
            IHashService hashService,
            IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _hashService = hashService;
            _mapper = mapper;
        }

        public async Task<MainAdminDto> Handle(RegisterMainAdminCommand request, CancellationToken cancellationToken)
        {
            var mainAdminCounter = await _unitOfWork.MainAdminQuery.CountAsync();
            if (mainAdminCounter > 0) 
                throw new AlreadyExistsException(ErrorMessage.GenerateErrorMessage(ErrorMessageType.MainAdminHasBeenFound, Array.Empty<string>()));
                
            var newMainAdmin = new MainAdmin();
            newMainAdmin.Init(
                Guid.NewGuid(),
                DateTime.UtcNow,
                DateTime.UtcNow,
                _configuration["MAIN_ADMIN_USERNAME"], 
                _configuration["MAIN_ADMIN_EMAIL"], 
                _configuration["MAIN_ADMIN_FIRST_NAME"], 
                _configuration["MAIN_ADMIN_LAST_NAME"],
                _hashService.ConvertStringToHash(_configuration["MAIN_ADMIN_PASSWORD"]));

            var created = await _unitOfWork.MainAdminRepository.CreateAsync(newMainAdmin);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<MainAdminDto>(created);
        }
    }
}
