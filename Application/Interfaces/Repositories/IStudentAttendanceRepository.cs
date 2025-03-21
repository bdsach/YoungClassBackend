namespace Application.Interfaces.Repositories
{
    using Domain.Entities;

    public interface IStudentAttendanceRepository
    {
        Task<IEnumerable<StudentAttendance>> GetAllAsync();
        Task<StudentAttendance?> GetByIdAsync(int id);
        Task<int> Create(StudentAttendance entity);
        Task Delete(StudentAttendance entity);
        Task SaveChanges();
    }
}

