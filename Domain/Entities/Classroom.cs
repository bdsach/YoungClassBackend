namespace Domain.Entities;

public class Classroom
{
    public int Id {get; set;}
    public string Name {get; set;} = default!;
    public string Description {get; set;} = default!;
    public string Category {get; set;} = default!;
    public User Owner {get; set;} = default!;
    public string OwnerId {get; set;} = default!;
    public List<ClassroomEnrollment> Enrollments {get; set;} = [];
    public List<StudentAttendance> StudentAttendances {get; set;} = [];
}