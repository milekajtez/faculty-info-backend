using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Domain.Abstractions.Mail.Services;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Enums.Email;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.FacultyAdmins.Commands.DeleteFacultyAdmin
{
    public class DeleteFacultyAdminCommandHandler : IRequestHandler<DeleteFacultyAdminCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;

        public DeleteFacultyAdminCommandHandler(IUnitOfWork unitOfWork, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        public async Task<Unit> Handle(DeleteFacultyAdminCommand request, CancellationToken cancellationToken)
        {
            var facultyAdmin = await _unitOfWork.FacultyAdminQuery
                .Find(e => e.Id == request.FacultyAdminId)
                .FirstOrDefaultAsync(cancellationToken) ??
                throw new NotFoundException(
                    ErrorMessage.GenerateErrorMessage(
                        ErrorMessageType.FacultyAdminHasNotFound, new string[1] { request.FacultyAdminId.ToString() }));

            await _mailService.SendAsync(
                EmailType.UserIsDeleted,
                facultyAdmin.Email,
                new
                {
                    firstName = facultyAdmin.FirstName,
                    lastName = facultyAdmin.LastName
                });

            _unitOfWork.FacultyAdminRepository.Delete(facultyAdmin);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
