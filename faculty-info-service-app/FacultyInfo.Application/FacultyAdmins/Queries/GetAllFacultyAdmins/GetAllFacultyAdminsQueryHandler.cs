using AutoMapper;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.FacultyAdmins.Queries.GetAllFacultyAdmins
{
    public class GetAllFacultyAdminsQueryHandler : IRequestHandler<GetAllFacultyAdminsQuery, IEnumerable<FacultyAdminDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllFacultyAdminsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacultyAdminDto>> Handle(GetAllFacultyAdminsQuery request, CancellationToken cancellationToken)
        {
            var facultyAdmins = await _unitOfWork.FacultyAdminQuery
                .GetAll()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<FacultyAdminDto>>(facultyAdmins);
        }
    }
}
