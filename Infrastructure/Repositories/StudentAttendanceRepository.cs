using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;
internal class StudentAttendanceRepository(ClassroomsDbContext dbContext) : IStudentAttendanceRepository
{
    public async Task<int> Create(StudentAttendance entity)
    {
        dbContext.StudentAttendances.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<int> BulkCreate(IEnumerable<StudentAttendance> entities)
    {
        await dbContext.StudentAttendances.AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();
        return entities.Count();
    }

    public Task<IEnumerable<StudentAttendance>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudentAttendance?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(StudentAttendance entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public Task SaveChanges()
    {
        return dbContext.SaveChangesAsync();
    }
}