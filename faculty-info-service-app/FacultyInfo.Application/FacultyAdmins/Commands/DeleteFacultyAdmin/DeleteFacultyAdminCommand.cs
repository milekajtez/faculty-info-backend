using MediatR;

namespace FacultyInfo.Application.FacultyAdmins.Commands.DeleteFacultyAdmin;

public sealed record DeleteFacultyAdminCommand(Guid FacultyAdminId) : IRequest;
