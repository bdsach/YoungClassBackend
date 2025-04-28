

namespace Domain.Entities;
public class TeacherProfile
{
    public int Id { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;

    // ข้อมูลส่วนตัวที่เฉพาะของครู
    public string SubjectSpecialization { get; set; } = default!;
    public string Degree { get; set; } = default!;
}