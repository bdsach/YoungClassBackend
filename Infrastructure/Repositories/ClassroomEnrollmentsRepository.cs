
using Domain.Entities;
using Application.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

internal class ClassroomEnrollmentsRepository(ClassroomsDbContext dbContext) : IClassroomEnrollmentsRepository
{
    public async Task<int> Create(ClassroomEnrollment entity)
    {
        dbContext.ClassroomEnrollments.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.ClassroomId;
    }
    
    public async Task<int> BulkCreate(IEnumerable<ClassroomEnrollment> entities)
    {
        await dbContext.ClassroomEnrollments.AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();
        return entities.Count();
    }

    // public async Task<List<ClassroomEnrollment>> BulkCreate(List<ClassroomEnrollment> entities)
    // {
    //     foreach (var item in entities)
    //     {
    //         // var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == item.Student.Email);
    //         // if (existingUser is null)
    //         // {
    //         //     var newStudent = new User
    //         //     {
    //         //         UserName = item.Student.UserName,
    //         //         Email = item.Student.Email
    //         //     };

    //         //     dbContext.Users.Add(newStudent);
    //         //     await dbContext.SaveChangesAsync();
    //         // }
    //         // else
    //         // {
    //         //     item.StudentId = existingUser.Id;
    //         // }
    //         dbContext.ClassroomEnrollments.Add(item);
    //         await dbContext.SaveChangesAsync();
    //     }
    //     return entities;
    // }

    public Task<IEnumerable<ClassroomEnrollment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ClassroomEnrollment?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(ClassroomEnrollment entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}