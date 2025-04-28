using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IClassroomsRepository
{
    Task<IEnumerable<Classroom>> GetAllAsync();
    Task<IEnumerable<Classroom>> GetAllClassroomByTeacher(string userId);
    Task<Classroom?> GetByIdAsync(int id);
    Task<int> Create(Classroom entity);
    Task Delete(Classroom entity);
    Task SaveChanges();
}