using FacultyInfo.Domain.Dtos.Student;
using MediatR;

namespace FacultyInfo.Application.Students.Commands.RegisterStudent
{
    public class RegisterStudentCommand : IRequest<StudentDto>
    {
    }
}
