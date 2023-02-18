using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Students.Commands.CreateStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<string>> CreateStudent(CreateStudentCommand createSubCommentCommand) 
        {
            return Ok("");
        }
    }
}
