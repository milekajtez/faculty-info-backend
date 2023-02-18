using FacultyInfo.Domain.Dtos.Student;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FacultyInfo.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<StudentDto>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
