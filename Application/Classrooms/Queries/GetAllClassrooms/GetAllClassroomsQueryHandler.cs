using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Classrooms.Dtos;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.Classrooms.Queries.GetAllClassrooms;

public class GetAllClassroomsQueryHandler(ILogger<GetAllClassroomsQueryHandler> logger,
    IMapper mapper,
    IClassroomsRepository classroomsRepository,
    IHttpContextAccessor httpContextAccessor
) : IRequestHandler<GetAllClassroomsQuery, IEnumerable<ClassroomDto>>
{
    public async Task<IEnumerable<ClassroomDto>> Handle(GetAllClassroomsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("getting all classrooms");
       
        var currentUserId = httpContextAccessor.HttpContext?.User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(currentUserId))
        {
            logger.LogWarning("Could not retrieve current user ID. Returning an empty list of classrooms.");
            return [];
        }

        var classrooms = await classroomsRepository.GetAllClassroomByTeacher(currentUserId);
        var classroomsDto = mapper.Map<IEnumerable<ClassroomDto>>(classrooms);

        return classroomsDto;
    }
}