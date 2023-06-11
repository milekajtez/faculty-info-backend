using AutoMapper;
using FacultyInfo.Application.Helpers.Error;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using FacultyInfo.Domain.Enums.ErrorMessage;
using FacultyInfo.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.FacultyAdmins.Queries.GetFacultyAdmins
{
    public class GetFacultyAdminsByFacultyIdQueryHandler : IRequestHandler<GetFacultyAdminsByFacultyIdQuery, IEnumerable<FacultyAdminDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFacultyAdminsByFacultyIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacultyAdminDto>> Handle(GetFacultyAdminsByFacultyIdQuery request, CancellationToken cancellationToken)
        {
            var facultyAdmins = await _unitOfWork.FacultyAdminQuery
                .Find(e => e.FacultyId == request.FacultyId)
                .ToListAsync(cancellationToken);

            if (facultyAdmins.Count == 0)
                throw new NotFoundException(
                     ErrorMessage.GenerateErrorMessage(ErrorMessageType.FacultyAdminHasNotFound, new string[1] { request.FacultyId.ToString() }));

            return _mapper.Map<List<FacultyAdminDto>>(facultyAdmins);
        }
    }
}
