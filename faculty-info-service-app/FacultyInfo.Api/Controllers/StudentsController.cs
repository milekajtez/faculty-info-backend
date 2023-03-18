using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Students.Commands.RegisterStudent;
using FacultyInfo.Domain.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class StudentsController : BaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult<StudentDto>> RegisterStudent(RegisterStudentCommand registerStudentCommand)
        {
            var student = await Mediator.Send(registerStudentCommand);

            return Created(student.Id.ToString(), student);
        }
    }
}
