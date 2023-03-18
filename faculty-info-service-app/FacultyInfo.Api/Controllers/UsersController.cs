using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Users.Queries.Login;
using FacultyInfo.Domain.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet("login/{email}/{password}")]
        public async Task<ActionResult<StudentDto>> RegisterStudent(string email, string password)
        {
            var token = await Mediator.Send(new LoginQuery(email, password));

            return Ok(token);
        }
    }
}
