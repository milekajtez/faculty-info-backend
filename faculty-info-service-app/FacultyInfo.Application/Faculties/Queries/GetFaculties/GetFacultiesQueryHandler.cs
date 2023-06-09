using AutoMapper;
using FacultyInfo.Domain.Abstractions.UnitOfWork;
using FacultyInfo.Domain.Dtos.Faculty;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacultyInfo.Application.Faculties.Queries.GetFaculties
{
    public class GetFacultiesQueryHandler : IRequestHandler<GetFacultiesQuery, IEnumerable<FacultyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFacultiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacultyDto>> Handle(GetFacultiesQuery request, CancellationToken cancellationToken)
        {
            var faculties = await _unitOfWork.FacultyQuery
                .GetAll()
                .OrderByDescending(e => e.Created)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<FacultyDto>>(faculties);
        }
    }
}
