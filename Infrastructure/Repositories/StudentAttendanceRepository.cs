using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class StudentAttendanceRepository(ClassroomsDbContext dbContext) : IStudentAttendanceRepository
{
    public async Task<int> Create(StudentAttendance entity)
    {
        dbContext.StudentAttendances.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public Task<IEnumerable<StudentAttendance>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudentAttendance?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(StudentAttendance entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}