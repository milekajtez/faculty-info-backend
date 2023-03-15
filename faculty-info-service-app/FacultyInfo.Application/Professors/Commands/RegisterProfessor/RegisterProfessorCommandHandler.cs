using FacultyInfo.Domain.Dtos.Professor;
using MediatR;

namespace FacultyInfo.Application.Professors.Commands.RegisterProfessor
{
    public class RegisterProfessorCommandHandler : IRequestHandler<RegisterProfessorCommand, ProfessorDto>
    {
        public Task<ProfessorDto> Handle(RegisterProfessorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
