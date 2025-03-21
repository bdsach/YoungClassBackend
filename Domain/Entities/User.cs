using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public List<Classroom> OwnedClassroom { get; set; } = [];
    public List<ClassroomEnrollment> Enrollments { get; set; } = [];
    public List<StudentAttendance> StudentAttendances {get; set;} = [];
}