using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Classrooms.Commands.CreateEnrollments;

public class CreateEnrollmentCommandHandler(
    ILogger<CreateEnrollmentCommandHandler> logger,
    IMapper mapper,
    IClassroomEnrollmentsRepository classroomEnrollmentsRepository,
    UserManager<User> userManager
    ) : IRequestHandler<CreateEnrollmentCommand, int>
{
    public async Task<int> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"accept data email: {request.Email} & username {request.UserName}, classroomId is {request.ClassroomId}");
        logger.LogInformation($"accept data email: {request.Email} & username {request.UserName}, classroomId is {request.ClassroomId}");

        var classroomEnrollment = mapper.Map<ClassroomEnrollment>(request);

        var existingUser = await userManager.FindByEmailAsync(request.Email);

        if (existingUser is null)
        {
            var newStudent = new User
            {
                UserName = request.Email,
                Email = request.Email
            };

            var createdStudentResult = await userManager.CreateAsync(newStudent, "Default_Password123");
            if (!createdStudentResult.Succeeded)
            {
                var errors = string.Join(", ", createdStudentResult.Errors.Select(e => e.Description));
                logger.LogError($"Failed to create user: {errors}");
                throw new Exception($"Failed to create user: {errors}");
            }
            existingUser = newStudent;
        }

        classroomEnrollment.StudentId = existingUser.Id;
        classroomEnrollment.ClassroomId = request.ClassroomId;
        classroomEnrollment.EnrolledDateUTC = DateTime.UtcNow;

        int id = await classroomEnrollmentsRepository.Create(classroomEnrollment);

        return id;

    }
}