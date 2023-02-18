using FacultyInfo.Domain.Dtos.Student;
using MediatR;

namespace FacultyInfo.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentDto>
    {
        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
