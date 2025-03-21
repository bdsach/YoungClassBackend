

namespace Application.ClassroomEnrollments.Dtos;

public class ClassroomEnrollmentDto
{
    public string UserId { get; set; } = default!;
    public int ClassroomId { get; set; }
    public DateTime EnrolledDateUTC { get; set; }
}