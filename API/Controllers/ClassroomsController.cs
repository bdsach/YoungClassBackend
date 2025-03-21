using MediatR;
using Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Application.Classrooms.Dtos;
using Microsoft.AspNetCore.Authorization;
using Application.Classrooms.Queries.GetAllClassrooms;
using Application.Classrooms.Queries.GetClassroomById;
using Application.Classrooms.Commands.CreateClassroom;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/classrooms")]
public class ClassroomsController(IMediator mediator): ControllerBase
{
    [HttpGet]
    // [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ClassroomDto>>> GetAll() 
    {
        var classrooms = await mediator.Send(new GetAllClassroomsQuery());
        return Ok(classrooms);
    }

    [HttpGet("{id}")]
    // [Authorize(Policy = PolicyNames.HasNationality)]
    // [Authorize(Policy = PolicyNames.AtLeast20)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var classroom = await mediator.Send(new GetClassroomByIdQuery(id));
        return Ok(classroom);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Teacher)]
    public async Task<IActionResult> CreateClassroom([FromBody] CreateClassroomCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}