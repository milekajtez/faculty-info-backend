using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Users.Queries.Login;
using FacultyInfo.Domain.Dtos.Student;
using FacultyInfo.Domain.Enums.User;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet("login/{email}/{password}/{userType}")]
        public async Task<ActionResult<StudentDto>> Login(string email, string password, UserType userType)
        {
            var token = await Mediator.Send(new LoginQuery(email, password, userType));

            return Ok(token);
        }
    }
}
