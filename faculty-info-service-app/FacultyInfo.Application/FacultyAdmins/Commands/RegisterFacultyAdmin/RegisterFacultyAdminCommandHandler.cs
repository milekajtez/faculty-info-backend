using FacultyInfo.Application.Professors.Commands.RegisterProfessor;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using FacultyInfo.Domain.Dtos.Professor;
using MediatR;

namespace FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin
{
    public class RegisterFacultyAdminCommandHandler : IRequestHandler<RegisterFacultyAdminCommand, FacultyAdminDto>
    {
        public Task<FacultyAdminDto> Handle(RegisterFacultyAdminCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
