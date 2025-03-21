using MediatR;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Application.Classrooms.Dtos;
using Microsoft.Extensions.Logging;

namespace Application.Classrooms.Queries.GetClassroomById;

public class GetClassroomByIdQueryHandler(ILogger<GetClassroomByIdQueryHandler> logger,
    IMapper mapper,
    IClassroomsRepository classroomsRepository) : IRequestHandler<GetClassroomByIdQuery, ClassroomDto>
{
    public async Task<ClassroomDto> Handle(GetClassroomByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting classroom {ClassroomId}", request.Id);
        var classroom = await classroomsRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Classroom), request.Id.ToString());
        var classroomDto = mapper.Map<ClassroomDto>(classroom);

        return classroomDto;
    }
}