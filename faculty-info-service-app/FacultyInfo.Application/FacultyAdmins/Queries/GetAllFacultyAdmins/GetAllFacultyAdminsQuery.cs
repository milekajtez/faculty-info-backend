using FacultyInfo.Domain.Dtos.FacultyAdmin;
using MediatR;

namespace FacultyInfo.Application.FacultyAdmins.Queries.GetAllFacultyAdmins;

public sealed record GetAllFacultyAdminsQuery() : IRequest<IEnumerable<FacultyAdminDto>>;
