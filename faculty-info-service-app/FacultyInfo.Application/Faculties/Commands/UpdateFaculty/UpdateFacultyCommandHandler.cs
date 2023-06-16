using AutoMapper;
using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.Faculty;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.Faculties.Commands.UpdateFaculty
{
    public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand, FacultyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFacultyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<FacultyDto> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
        {
            var faculty = await _unitOfWork.FacultyRepository
                .Find(e => e.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken) ?? 
                throw new NotFoundException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.FacultyHasNotFound, new string[1] { request.Id.ToString() }));

            faculty = Faculty.Update(faculty, request.Tin, request.Name, request.Description, request.Location);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<FacultyDto>(faculty);
        }
    }
}
