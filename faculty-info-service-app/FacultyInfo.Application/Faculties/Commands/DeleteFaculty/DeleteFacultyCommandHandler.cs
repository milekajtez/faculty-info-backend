using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.Faculties.Commands.DeleteFaculty
{
    public class DeleteFacultyCommandHandler : IRequestHandler<DeleteFacultyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFacultyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
        {
            var faculty = await _unitOfWork.FacultyQuery
                .Find(e => e.Id == request.FacultyId)
                .FirstOrDefaultAsync(cancellationToken) ??
                throw new NotFoundException(
                    ErrorMessage.GenerateErrorMessage(
                        ErrorMessageType.FacultyHasNotFound, new string[1] { request.FacultyId.ToString() }));

            _unitOfWork.FacultyRepository.Delete(faculty);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
