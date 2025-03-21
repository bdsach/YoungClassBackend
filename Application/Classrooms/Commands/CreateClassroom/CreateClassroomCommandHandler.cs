

using Application.Users;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Classrooms.Commands.CreateClassroom;

public class CreateClassroomCommandHandler(ILogger<CreateClassroomCommandHandler> logger,
    IMapper mapper,
    IClassroomsRepository classroomsRepository,
    IUserContext userContext) : IRequestHandler<CreateClassroomCommand, int>
{
    public async Task<int> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        if (currentUser is null)
        {
            logger.LogError("No authenticated user found while attempting to create a classroom.");
            throw new InvalidOperationException("Cannot Create classroom without an authenticated user.");
        }

        logger.LogInformation("{UserName} [{UserId}] Creating a new classroom {@Classroom}",
            currentUser.Email,
            currentUser.Id,
            request);

        var classroom = mapper.Map<Classroom>(request);
        classroom.OwnerId = currentUser.Id;

        int id = await classroomsRepository.Create(classroom);

        return id;
    }
}