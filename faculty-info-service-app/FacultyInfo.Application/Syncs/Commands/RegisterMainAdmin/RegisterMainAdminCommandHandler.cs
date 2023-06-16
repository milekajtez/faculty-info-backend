using AutoMapper;
using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.MainAdmin;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var mainAdminEmail = _configuration["MAIN_ADMIN_EMAIL"];
            var mainAdminSecurity = await _unitOfWork.MainAdminQuery
                .Find(e => e.Email == mainAdminEmail)
                .FirstOrDefaultAsync(cancellationToken);

            if (mainAdminSecurity is not null) 
                throw new AlreadyExistsException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.MainAdminHasBeenFound, Array.Empty<string>()));
                
            var newMainAdmin = new MainAdmin();
            newMainAdmin.Init(
                Guid.NewGuid(), 
                DateTime.UtcNow, 
                DateTime.UtcNow,
                mainAdminEmail, 
                _configuration["MAIN_ADMIN_FIRST_NAME"],
                _configuration["MAIN_ADMIN_LAST_NAME"],
                _hashService.ConvertStringToHash(_configuration["MAIN_ADMIN_PASSWORD"]));

            var createdMainAdmin = await _unitOfWork.MainAdminRepository.CreateAsync(newMainAdmin);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<MainAdminDto>(createdMainAdmin);
        }
    }
}
