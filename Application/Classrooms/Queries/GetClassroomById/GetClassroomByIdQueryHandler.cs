using MediatR;
using AutoMapper;
using Domain.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Classrooms.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Application.Classrooms.Queries.GetClassroomById;

public class GetClassroomByIdQueryHandler(ILogger<GetClassroomByIdQueryHandler> logger,
    IMapper mapper,
    IClassroomsRepository classroomsRepository,
    IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetClassroomByIdQuery, ClassroomDto>
{
    public async Task<ClassroomDto> Handle(GetClassroomByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting classroom {ClassroomId}", request.Id);
        var currentUserId = httpContextAccessor.HttpContext?.User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        var classroom = await classroomsRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Classroom), request.Id.ToString());
        
        if (currentUserId != classroom.OwnerId) {
            throw new NotFoundException(nameof(Classroom), request.Id.ToString());
        }
        
        var classroomDto = mapper.Map<ClassroomDto>(classroom);

        return classroomDto;
    }
}