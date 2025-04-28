namespace Application.Classrooms.Dtos;
public class StudentDto
{
    public string Id { get; set; } = default!;
    public string StudentId { get; set; } = default!; // รหัสนักเรียน
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}