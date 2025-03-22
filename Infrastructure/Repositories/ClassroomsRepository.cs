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

    public async Task Delete(Classroom entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public Task SaveChanges()
    {
        return dbContext.SaveChangesAsync();
    }
}