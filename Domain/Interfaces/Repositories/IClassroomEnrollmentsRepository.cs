using Domain.Entities;

namespace Domain.Repositories;

public interface IClassroomEnrollmentsRepository
{
    Task<IEnumerable<ClassroomEnrollment>> GetAllAsync();
    Task<ClassroomEnrollment?> GetByIdAsync(int id);
    Task<int> Create(ClassroomEnrollment entity);
    Task<int> BulkCreate(IEnumerable<ClassroomEnrollment> entities); // New method
    Task Delete(ClassroomEnrollment entity);
    Task SaveChanges();
}