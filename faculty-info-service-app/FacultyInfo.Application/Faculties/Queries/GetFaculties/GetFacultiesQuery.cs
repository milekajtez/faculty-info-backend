using FacultyInfo.Domain.Dtos.Faculty;
using MediatR;

namespace FacultyInfo.Application.Faculties.Queries.GetFaculties;

public sealed record GetFacultiesQuery() : IRequest<IEnumerable<FacultyDto>>;
