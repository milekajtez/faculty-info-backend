using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Faculties.Commands.CreateFaculty;
using FacultyInfo.Application.Faculties.Queries.GetFaculties;
using FacultyInfo.Domain.Dtos.Faculty;
using Microsoft.AspNetCore.Mvc;

namespace FacultyInfo.Api.Controllers
{
    public class FacultiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<FacultyDto>>> GetFaculties()
        {
            var faculties = await Mediator.Send(new GetFacultiesQuery());

            return Ok(faculties);
        }

        [HttpPost]
        public async Task<ActionResult<FacultyDto>> CreateFaculty(CreateFacultyCommand createFacultyCommand)
        {
            var faculty = await Mediator.Send(createFacultyCommand);

            return Created(faculty.Id.ToString(), faculty);
        }
    }
}
