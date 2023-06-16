﻿using FacultyInfo.Api.Controllers.Base;
using FacultyInfo.Application.Faculties.Commands.CreateFaculty;
using FacultyInfo.Application.Faculties.Commands.DeleteFaculty;
using FacultyInfo.Application.Faculties.Commands.UpdateFaculty;
using FacultyInfo.Application.Faculties.Queries.GetFaculties;
using FacultyInfo.Domain.Dtos.Faculty;
using MediatR;
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

        [HttpDelete("{facultyId}")]
        public async Task<ActionResult<Unit>> DeleteFaculty(Guid facultyId)
        {
            await Mediator.Send(new DeleteFacultyCommand(facultyId));

            return Ok();
        }

        [HttpPut("{facultyId}")]
        public async Task<ActionResult<Unit>> UpdateFaculty(Guid facultyId, UpdateFacultyCommand updateFacultyCommand)
        {
            if (facultyId != updateFacultyCommand.Id)
                return BadRequest(new { message = "ID in URL and ID in request body must be the same" });

            var faculty = await Mediator.Send(updateFacultyCommand);

            return Ok(faculty);
        }
    }
}
