namespace Domain.Entities;

public class Classroom
{
    public int Id {get; set;}
    public string Subject {get; set;} = default!;
    public string Description {get; set;} = default!;
    public string GradeLevel { get; set; } = default!; // ระดับชั้น
    public string Room { get; set; } = default!;  // ห้อง
    public string SubjectGroup { get; set; } = default!; // กลุ่มสาระ
    public User Owner {get; set;} = default!;
    public string OwnerId {get; set;} = default!;
    public List<ClassroomEnrollment> Enrollments {get; set;} = [];
    public List<StudentAttendance> StudentAttendances {get; set;} = [];
}