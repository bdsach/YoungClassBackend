

using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

internal class StudentProfileRepository(ClassroomsDbContext dbContext) : IStudentProfileRepository
{
     public async Task<int> Create(StudentProfile entity)
    {
        dbContext.StudentProfiles.Add(entity);
        await dbContext.SaveChangesAsync();
        // return entity.Id;
        return 1;
    }

    public Task Delete(StudentProfile entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StudentProfile>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudentProfile?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}