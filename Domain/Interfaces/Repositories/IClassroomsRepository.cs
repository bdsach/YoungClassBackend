using Domain.Entities;

namespace Domain.Repositories;

public interface IClassroomsRepository
{
    Task<IEnumerable<Classroom>> GetAllAsync();
    Task<Classroom?> GetByIdAsync(int id);
    Task<int> Create(Classroom entity);
    Task Delete(Classroom entity);
    Task SaveChanges();
}