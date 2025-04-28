

namespace Application.Classrooms.Dtos;

public class ClassroomDto
{
    public int Id { get; set; }
    public string Subject { get; set; } = default!;
    public string GradeLevel { get; set; } = default!;
    public string Room { get; set; } = default!;
    public string SubjectGroup { get; set; } = default!;
    public List<StudentDto> Students { get; set; } = [];
}