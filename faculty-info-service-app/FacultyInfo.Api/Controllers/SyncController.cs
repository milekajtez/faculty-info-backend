using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Syncs.Commands.RegisterMainAdmin;
using FacultyInfo.Domain.Dtos.MainAdmin;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class SyncController : BaseController
    {
        [HttpPost("registerMainAdmin")]
        public async Task<ActionResult<MainAdminDto>> RegisterMainAdmin(RegisterMainAdminCommand registerMainAdminCommand)
        {
            var mainAdmin = await Mediator.Send(registerMainAdminCommand);
            
            return Created(mainAdmin.Id.ToString(), mainAdmin);
        }
    }
}
