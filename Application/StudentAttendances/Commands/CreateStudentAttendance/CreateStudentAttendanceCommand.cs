using MediatR;
using System.Text.Json.Serialization;

namespace Application.StudentAttendances.Commands.CreateAttendance;

public class CreateStudentAttendanceCommand : IRequest<int>
{
    [JsonIgnore]
    public int ClassroomId { get; set; } = default!;
    public string StudentId { get; set; } = default!;
    public bool IsPresent { get; set; }
}