using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class FacultyAdminsController : BaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult<FacultyAdminDto>> RegisterFacultyAdmin(RegisterFacultyAdminCommand registerFacultyAdminCommand)
        {
            var facultyAdmin = await Mediator.Send(registerFacultyAdminCommand);

            return Created(facultyAdmin.Id.ToString(), facultyAdmin);
        }
    }
}
