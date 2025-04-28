

namespace Application.ClassroomEnrollments.Dtos;
public class BulkCreateEnrollmentsDto
{
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string StudentId { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}