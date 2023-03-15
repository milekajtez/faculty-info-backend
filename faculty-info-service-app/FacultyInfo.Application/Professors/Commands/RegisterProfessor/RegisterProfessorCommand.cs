using FacultyInfo.Domain.Dtos.Professor;
using MediatR;

namespace FacultyInfo.Application.Professors.Commands.RegisterProfessor
{
    public class RegisterProfessorCommand : IRequest<ProfessorDto>
    {
    }
}
