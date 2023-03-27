using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Faculties.Commands.CreateFaculty;
using FacultyInfo.Domain.Dtos.Faculty;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class FacultiesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<FacultyDto>> CreateFaculty(CreateFacultyCommand createFacultyCommand)
        {
            var faculty = await Mediator.Send(createFacultyCommand);

            return Created(faculty.Id.ToString(), faculty);
        }
    }
}
