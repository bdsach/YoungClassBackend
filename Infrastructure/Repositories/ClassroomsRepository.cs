using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class ClassroomsRepository(ClassroomsDbContext dbContext) : IClassroomsRepository
{
    public async Task<int> Create(Classroom entity)
    {
        dbContext.Classrooms.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Classroom>> GetAllAsync()
    {
        var classrooms = await dbContext.Classrooms.ToListAsync();
        return classrooms;
    }

    public async Task<Classroom?> GetByIdAsync(int id)
    {
        var classroom = await dbContext.Classrooms
            .FirstOrDefaultAsync(c => c.Id == id);
        return classroom;
    }

    public Task Delete(Classroom entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}