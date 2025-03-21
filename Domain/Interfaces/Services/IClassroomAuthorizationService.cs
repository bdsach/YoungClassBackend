using Domain.Constants;
using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IClassroomAuthorizationService
{
    bool Authorize(Classroom classroom, ResourceOperation resourceOperation);
}