

namespace Application.StudentAttendances.Dtos;

public class BulkCreateStudentAttendancesDto
{
    public string StudentId { get; set; } = default!;
    public bool IsPresent { get; set; }
}