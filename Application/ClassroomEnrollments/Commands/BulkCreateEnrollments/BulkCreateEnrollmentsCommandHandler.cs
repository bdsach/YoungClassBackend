using MediatR;
using Domain.Entities;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Domain.Constants;

namespace Application.ClassroomEnrollments.Commands.BulkCreateEnrollments;

public class BulkCreateEnrollmentsCommandHandler(
    UserManager<User> userManager,
    ILogger<BulkCreateEnrollmentsCommandHandler> logger,
    IClassroomEnrollmentsRepository classroomEnrollmentsRepository,
    IStudentProfileRepository studentProfileRepository
) : IRequestHandler<BulkCreateEnrollmentsCommand, int>
{
    public async Task<int> Handle(BulkCreateEnrollmentsCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("ClassroomId {Classroom}", request.ClassroomId);

        var enrollments = new List<ClassroomEnrollment>();

        foreach (var enrollment in request.Enrollments)
        {
            logger.LogInformation($"Processing enrollment for email: {enrollment.Email} & username {enrollment.UserName}");

            var existingUser = await userManager.FindByEmailAsync(enrollment.Email);

            if (existingUser is null)
            {
                var newStudent = new User
                {
                    UserName = enrollment.Email,
                    Email = enrollment.Email
                };

                var createdStudentResult = await userManager.CreateAsync(newStudent, DefaultValue.Password);
                if (!createdStudentResult.Succeeded)
                {
                    var errors = string.Join(", ", createdStudentResult.Errors.Select(e => e.Description));
                    logger.LogError($"Failed to create user: {errors}");
                    throw new Exception($"Failed to create user: {errors}");
                }

                var addRoleResult = await userManager.AddToRoleAsync(newStudent, UserRoles.Student);
                if (!addRoleResult.Succeeded)
                {
                    var roleErrors = string.Join(", ", addRoleResult.Errors.Select(e => e.Description));
                    logger.LogError($"Failed to assign 'Student' role: {roleErrors}");
                    throw new Exception($"Failed to assign 'Student' role: {roleErrors}");
                }

                existingUser = newStudent;
            }

            var userProfile = new StudentProfile
            {
                UserId = existingUser.Id,
                StudentId = enrollment.StudentId,
                FirstName = enrollment.FirstName,
                LastName = enrollment.LastName,
            };

            await studentProfileRepository.Create(userProfile);

            var classroomEnrollment = new ClassroomEnrollment
            {
                StudentId = existingUser.Id,
                ClassroomId = request.ClassroomId,
                EnrolledDateUTC = DateTime.UtcNow
            };

            enrollments.Add(classroomEnrollment);
        }

        await classroomEnrollmentsRepository.BulkCreate(enrollments);

        return enrollments.Count;
    }
}