using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IStudentProfileRepository
{
    Task<IEnumerable<StudentProfile>> GetAllAsync();
    Task<StudentProfile?> GetByIdAsync(int id);
    Task<int> Create(StudentProfile entity);
    Task Delete(StudentProfile entity);
    Task SaveChanges();
}