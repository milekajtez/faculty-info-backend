using FacultyInfo.Domain.Dtos.Student;
using MediatR;

namespace FacultyInfo.Application.Students.Commands.RegisterStudent
{
    public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, StudentDto>
    {
        public Task<StudentDto> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
