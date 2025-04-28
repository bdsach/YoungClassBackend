using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class StudentProfile
{
    [Key]
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;

    // ข้อมูลส่วนตัวที่เฉพาะของนักเรียน
    public string StudentId { get; set; } = default!; // รหัสนักเรียน
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}