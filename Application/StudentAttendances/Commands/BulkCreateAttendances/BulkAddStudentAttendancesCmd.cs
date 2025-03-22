using MediatR;
using Application.StudentAttendances.Dtos;
using System.Text.Json.Serialization;

namespace Application.StudentAttendances.Commands.BulkCreateStudentAttendances;

public class BulkCreateStudentAttendancesCmd : IRequest<int>
{
    [JsonIgnore]
    public int ClassroomId {get; set;} = default!;
    public List<BulkCreateStudentAttendancesDto> StudentAttendances { get; set; } = [];
}