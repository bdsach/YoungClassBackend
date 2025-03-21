using Application.Users;
using Domain.Constants;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Authorization.Services;

public class ClassroomAuthorizationService(ILogger<ClassroomAuthorizationService> logger, IUserContext userContext) : IClassroomAuthorizationService
{
    public bool Authorize(Classroom classroom, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser() ?? throw new InvalidOperationException("This User is unauthorize.");

        logger.LogInformation("Authorizing user {UserEmail} to {Operation} for Classroom {ClassroomName}",
            user.Email,
            resourceOperation,
            classroom.Name
        );

        if (resourceOperation == ResourceOperation.Create || resourceOperation == ResourceOperation.Read)
        {
            logger.LogInformation("Create/Read operation - successfully authorization.");
            return true;
        }

        if (resourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin user, delete operation - successfully authorization.");
            return true;
        }

        if ((resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update) && user.Id == classroom.OwnerId)
        {
            logger.LogInformation("Classroom Owner Update/delete operation - successfully authorization.");
            return true;
        }

        return false;
    }
}