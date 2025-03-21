using Domain.Interfaces;

namespace Domain.Entities;

public class StudentAttendance : BaseEntity, IBaseEntity
{
    public int Id { get; set; }
    public string StudentId { get; set; } = default!;
    public int ClassroomId { get; set; }
    public DateTime DateUTC { get; set; }
    public bool IsPresent { get; set; }
    public virtual User Student { get; set; } = default!;
    public virtual Classroom Classroom { get; set; } = default!;
}