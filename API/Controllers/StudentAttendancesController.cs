using MediatR;
using Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.StudentAttendances.Commands.CreateAttendance;
using Application.StudentAttendances.Commands.BulkCreateStudentAttendances;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/student-attendances")]
public class StudentAttendanceController(IMediator mediator) : ControllerBase
{
    [HttpPost("{classroomId}")]
    [Authorize(Roles = UserRoles.Teacher)]
    public async Task<IActionResult> CreateStudentAttendance([FromBody] CreateStudentAttendanceCommand command, int classroomId)
    {
        command.ClassroomId = classroomId;
        int id = await mediator.Send(command);
        // return CreatedAtAction(nameof(GetById), new { id }, null);
        return CreatedAtAction(null, new { id }, null);
    }

    [HttpPost("{classroomId}/bulk")]
    [Authorize(Roles = UserRoles.Teacher)]
    public async Task<IActionResult> BulkCreateStudentAttendance([FromBody] BulkCreateStudentAttendancesCmd command, [FromRoute] int classroomId)
    {
        command.ClassroomId = classroomId;
        await mediator.Send(command);
        
        return Ok();
    }
}