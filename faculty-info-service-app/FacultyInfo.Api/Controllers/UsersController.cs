using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult<string>> CreateUser(CreateUserCommand createUserCommand) 
        {
            var user = await Mediator.Send(createUserCommand);

            return Created(user.UserId.ToString(), user);
        }
    }
}
