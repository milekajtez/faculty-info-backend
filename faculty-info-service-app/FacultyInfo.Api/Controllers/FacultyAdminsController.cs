using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.FacultyAdmins.Commands.DeleteFacultyAdmin;
using FacultyInfo.Application.FacultyAdmins.Commands.RegisterFacultyAdmin;
using FacultyInfo.Application.FacultyAdmins.Queries.GetFacultyAdmins;
using FacultyInfo.Domain.Dtos.FacultyAdmin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class FacultyAdminsController : BaseController
    {
        [HttpGet("{facultyId}")]
        public async Task<ActionResult<List<FacultyAdminDto>>> GetFacultyAdminsByFacultyId(Guid facultyId) 
        {
            var facultyAdmins = await Mediator.Send(new GetFacultyAdminsByFacultyIdQuery(facultyId));

            return Ok(facultyAdmins);
        }


        [HttpPost("register")]
        public async Task<ActionResult<FacultyAdminDto>> RegisterFacultyAdmin(RegisterFacultyAdminCommand registerFacultyAdminCommand)
        {
            var facultyAdmin = await Mediator.Send(registerFacultyAdminCommand);

            return Created(facultyAdmin.Id.ToString(), facultyAdmin);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteFacultyAdmin(Guid id)
        {
            await Mediator.Send(new DeleteFacultyAdminCommand(id));

            return Ok();
        }
    }
}
