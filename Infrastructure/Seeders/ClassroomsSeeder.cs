using Domain.Constants;
using Domain.Entities;
using Application.Interfaces.Seeder;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seeders;

internal class ClassroomsSeeder(ClassroomsDbContext dbContext, 
    UserManager<User> userManager, 
    RoleManager<IdentityRole> roleManager ) : IClassroomsSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            // if (!dbContext.Classrooms.Any())
            // {
            //     var classrooms = GetClassrooms();
            //     dbContext.Classrooms.AddRange(classrooms);
            //     await dbContext.SaveChangesAsync();
            // }

            if (!dbContext.Users.Any())
            {
                var users = GetUsers();
                var initialPassword = "pAssword_123";
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, initialPassword);
                }
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }

            // add admin
            var adminUser = await userManager.FindByEmailAsync("admin@email.com");
            if (adminUser is not null)
            {
                var adminRoleExists = await roleManager.RoleExistsAsync(UserRoles.Admin);
                if (adminRoleExists)
                {
                    await userManager.AddToRoleAsync(adminUser, UserRoles.Admin);
                }
            }

            // add teacher
        }
    }
    
    private IEnumerable<User> GetUsers()
    {
        List<User> users = [
            new User
            {
                UserName = "admin@email.com",
                Email = "admin@email.com",
            }

        ];
        return users;
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
        [
            new (UserRoles.Student)
            {
                NormalizedName = UserRoles.Student.ToUpper()
            },
            new (UserRoles.Teacher)
            {
                NormalizedName = UserRoles.Teacher.ToUpper()
            },
            new (UserRoles.Admin)
            {
                NormalizedName = UserRoles.Admin.ToUpper()
            },
        ];

        return roles;
    }

    // private IEnumerable<Classroom> GetClassrooms()
    // {
    //     List<Classroom> classrooms = new()
    //     {
    //         new Classroom
    //         {
    //             Name = "ห้องเรียนที่หนึ่ง",

    //         }
    //     };

    //     return classrooms;

    // }
}