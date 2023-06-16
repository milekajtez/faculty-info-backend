using AutoMapper;
using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin
{
    public class RegisterFacultyAdminCommandHandler : IRequestHandler<RegisterFacultyAdminCommand, FacultyAdminDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashService _hashService;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public RegisterFacultyAdminCommandHandler(
            IUnitOfWork unitOfWork, 
            IHashService hashService,
            IMapper mapper,
            IMailService mailService) 
        {
            _unitOfWork = unitOfWork;
            _hashService = hashService;
            _mapper = mapper;
            _mailService = mailService;
        }

        public async Task<FacultyAdminDto> Handle(RegisterFacultyAdminCommand request, CancellationToken cancellationToken)
        {
            var facultyAdmin = await _unitOfWork.FacultyAdminQuery
                .Find(e => e.Email == request.Email)
                .FirstOrDefaultAsync(cancellationToken);

            if (facultyAdmin is not null)
                throw new AlreadyExistsException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.FacultyAdminHasBeenFound, Array.Empty<string>()));
            
            var tempPassword = _hashService.GenerateTempPassword();

            var newFacultyAdmin = new FacultyAdmin();
            newFacultyAdmin.Init(
                Guid.NewGuid(),
                DateTime.UtcNow,
                DateTime.UtcNow,
                request.Email,
                request.FirstName,
                request.LastName,
                request.FacultyId,
                _hashService.ConvertStringToHash(tempPassword));

            var createdFacultyAdmin = await _unitOfWork.FacultyAdminRepository.CreateAsync(newFacultyAdmin);

            await _unitOfWork.CompleteAsync();

            await _mailService.SendAsync(
                createdFacultyAdmin.Email,
                createdFacultyAdmin.FirstName,
                createdFacultyAdmin.LastName,
                tempPassword);

            return _mapper.Map<FacultyAdminDto>(createdFacultyAdmin); 
        }
    }
}
