using MediatR;
using Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.StudentAttendance.Commands.CreateAttendance;

namespace API.Controllers;

[ApiController]
[Authorize]
[Route("api/attendance")]
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
}