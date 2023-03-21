using AutoMapper;
using FacultyInfo.Application.Helpers.Hash;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Enums.User;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Exceptions.Messages;
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
            var security = await _unitOfWork.SecurityQuery
                .Find(e => e.Email == request.Email)
                .FirstOrDefaultAsync(cancellationToken);

            if (security is not null)
                throw new AlreadyExistsException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.FacultyAdminHasBeenFound, Array.Empty<string>()));

            var facultyAdmin = new FacultyAdmin();
            facultyAdmin.Init(
                Guid.NewGuid(),
                DateTime.UtcNow,
                DateTime.UtcNow,
                request.Email,
                request.FirstName,
                request.LastName);

            var tempPassword = _hashService.GenerateTempPassword();

            var facultyAdminSecurity = new Security();
            facultyAdminSecurity.Init(
                Guid.NewGuid(),
                DateTime.UtcNow,
                DateTime.UtcNow,
                request.Email,
                _hashService.ConvertStringToHash(tempPassword),
                UserType.FacultyAdmin);

            var createdFacultyAdmin = await _unitOfWork.FacultyAdminRepository.CreateAsync(facultyAdmin);
            var createdSecurity = await _unitOfWork.SecurityRepository.CreateAsync(facultyAdminSecurity);

            await _unitOfWork.CompleteAsync();

            _mailService.SendEmail(request.Email);

            // dodavanje migracije
            // testirati kreiranje faculty admin-a
            // napisati testove (Mail Service + create faculty admin)
            // create faculty
            // testiranje create faculty
            // faculties - get
            // faculty admins - get
            // testovi za get metode

            return _mapper.Map<FacultyAdminDto>(createdFacultyAdmin); 
        }
    }
}
