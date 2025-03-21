
using Domain.Entities;
using Application.Interfaces.Seeder;
using Application.Interfaces.Services;
using Application.Interfaces.Repositories;
using Infrastructure.Authorization;
using Infrastructure.Authorization.Services;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ClassroomsDb");
        services.AddDbContext<ClassroomsDbContext>(option => 
            option.UseNpgsql(connectionString)
            .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<ClassroomsUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<ClassroomsDbContext>();

        services.AddScoped<IClassroomsSeeder, ClassroomsSeeder>();
        services.AddScoped<IClassroomsRepository, ClassroomsRepository>();
        services.AddScoped<IClassroomEnrollmentsRepository, ClassroomEnrollmentsRepository>();
        services.AddScoped<IStudentAttendanceRepository, StudentAttendanceRepository>();

        // services.AddAuthorizationBuilder()
        //     .AddPolicy(PolicyNames.HasNationality, 
        //         builder => builder.RequireClaim(AppClaimTypes.Nationality, "German", "Polish"))
        //     .AddPolicy(PolicyNames.AtLeast20, 
        //         builder => builder.AddRequirements(new MinimumAgeRequirement(20)));
        
        // services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
        services.AddScoped<IClassroomAuthorizationService, ClassroomAuthorizationService>();
    }
}