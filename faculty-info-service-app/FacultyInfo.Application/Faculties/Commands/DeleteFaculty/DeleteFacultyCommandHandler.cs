using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Enums.Email;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.Faculties.Commands.DeleteFaculty
{
    public class DeleteFacultyCommandHandler : IRequestHandler<DeleteFacultyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;

        public DeleteFacultyCommandHandler(IUnitOfWork unitOfWork, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        public async Task<Unit> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
        {
            var faculty = await _unitOfWork.FacultyQuery
                .Find(e => e.Id == request.FacultyId)
                .FirstOrDefaultAsync(cancellationToken) ??
                throw new NotFoundException(
                    ErrorMessage.GenerateErrorMessage(
                        ErrorMessageType.FacultyHasNotFound, new string[1] { request.FacultyId.ToString() }));

            var facultyAdmins = await _unitOfWork.FacultyAdminQuery
                .Find(e => e.FacultyId == faculty.Id)
                .ToListAsync(cancellationToken);

            foreach (var facultyAdmin in facultyAdmins) 
                await _mailService.SendAsync(
                    EmailType.UserIsDeleted, 
                    facultyAdmin.Email, 
                    new 
                    { 
                        firstName = facultyAdmin.FirstName,
                        lastName = facultyAdmin.LastName
                    });
            
            _unitOfWork.FacultyRepository.Delete(faculty);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
