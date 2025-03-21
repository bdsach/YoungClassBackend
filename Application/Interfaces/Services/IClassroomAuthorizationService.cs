using Domain.Constants;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IClassroomAuthorizationService
{
    bool Authorize(Classroom classroom, ResourceOperation resourceOperation);
}