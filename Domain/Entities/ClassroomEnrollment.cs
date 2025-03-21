namespace Domain.Entities;

public class ClassroomEnrollment
{
    public string StudentId { get; set; } = default!;
    public User Student { get; set; } = default!;
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; } = default!;
    public DateTime EnrolledDateUTC { get; set; }
}