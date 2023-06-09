using AutoMapper;
using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.Faculty;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.Faculties.Commands.CreateFaculty
{
    public class CreateFacultyCommandHandler : IRequestHandler<CreateFacultyCommand, FacultyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFacultyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FacultyDto> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            var faculty = await _unitOfWork.FacultyQuery
                .Find(e => e.Tin == request.Tin)
                .FirstOrDefaultAsync(cancellationToken);

            if (faculty is not null)
                throw new AlreadyExistsException(
                    ErrorMessage.GenerateErrorMessage(ErrorMessageType.FacultyHasBeenFound, new string[1] { faculty.Tin }));

            var newFaculty = new Faculty();
            newFaculty.Init(
                Guid.NewGuid(),
                DateTime.UtcNow,
                DateTime.UtcNow,
                request.Tin,
                request.Name,
                request.Description,
                request.Location);

            var created = await _unitOfWork.FacultyRepository.CreateAsync(newFaculty);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<FacultyDto>(created);
        }
    }
}
