using MediatR;
using Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Classrooms.Commands.CreateEnrollments;
using Application.ClassroomEnrollments.Commands.BulkCreateEnrollments;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/classrooms-enrollments")]
public class ClassroomEnrollmentsController(IMediator mediator) : ControllerBase
{

    [HttpPost("{classroomId}")]
    [Authorize(Roles = UserRoles.Teacher)]
    public async Task<IActionResult> EnrollStudent([FromBody] CreateEnrollmentCommand command, [FromRoute] int classroomId)
    {
        command.ClassroomId = classroomId;
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost("{classroomId}/bulk")]
    [Authorize(Roles = UserRoles.Teacher)]
    public async Task<IActionResult> BulkEnrollStudents([FromBody] BulkCreateEnrollmentsCommand command, [FromRoute] int classroomId)
    {
        command.ClassroomId = classroomId;
        await mediator.Send(command);
        
        return Ok();
    }

}