using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Professors.Commands.RegisterProfessor;
using FacultyInfo.Domain.Dtos.Professor;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class ProfessorsController : BaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult<ProfessorDto>> RegisterProfessor(RegisterProfessorCommand registerProfessorCommand)
        {
            var professor = await Mediator.Send(registerProfessorCommand);

            return Created(professor.Id.ToString(), professor);
        }
    }
}
