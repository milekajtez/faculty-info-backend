using MediatR;

namespace FacultyInfo.Application.Faculties.Commands.DeleteFaculty;

public sealed record DeleteFacultyCommand(Guid FacultyId) : IRequest;
