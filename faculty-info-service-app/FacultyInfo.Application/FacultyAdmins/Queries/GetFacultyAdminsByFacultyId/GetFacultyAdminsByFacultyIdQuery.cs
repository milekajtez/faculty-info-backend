using FacultyInfo.Domain.Dtos.FacultyAdmin;
using MediatR;

namespace FacultyInfo.Application.FacultyAdmins.Queries.GetFacultyAdmins;

public sealed record GetFacultyAdminsByFacultyIdQuery(Guid FacultyId) : IRequest<IEnumerable<FacultyAdminDto>>;

