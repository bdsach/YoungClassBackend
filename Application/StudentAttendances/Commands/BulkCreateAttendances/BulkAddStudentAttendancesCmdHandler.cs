using MediatR;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repositories;

namespace Application.StudentAttendances.Commands.BulkCreateStudentAttendances;

public class BulkCreateStudentAttendancesCmdHandler(
    ILogger<BulkCreateStudentAttendancesCmdHandler> logger,
    IStudentAttendanceRepository studentAttendanceRepository
    ) : IRequestHandler<BulkCreateStudentAttendancesCmd, int>
{
    public async Task<int> Handle(BulkCreateStudentAttendancesCmd request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Add Attendance to ClassroomId {Classroom}", request.StudentAttendances);

        var studentAttendances = new List<StudentAttendance>();

        foreach (var studentAttendance in request.StudentAttendances)
        {
            logger.LogInformation($"Processing studentAttendance for StudentId: {studentAttendance.StudentId}");

            var newStudentAttendance = new StudentAttendance()
            {
                StudentId = studentAttendance.StudentId,
                ClassroomId = request.ClassroomId,
                IsPresent = studentAttendance.IsPresent,
                DateUTC = DateTime.UtcNow,
                CreatedUTC = DateTime.UtcNow,
                UpdatedUTC = DateTime.UtcNow
            };
            studentAttendances.Add(newStudentAttendance);
        }
        
        await studentAttendanceRepository.BulkCreate(studentAttendances);

        return studentAttendances.Count;
    }
}