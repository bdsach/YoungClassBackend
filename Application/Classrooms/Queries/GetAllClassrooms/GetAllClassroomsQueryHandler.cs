using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Classrooms.Dtos;
using Domain.Repositories;

namespace Application.Classrooms.Queries.GetAllClassrooms;

public class GetAllClassroomsQueryHandler(ILogger<GetAllClassroomsQueryHandler> logger,
    IMapper mapper,
    IClassroomsRepository classroomsRepository
) : IRequestHandler<GetAllClassroomsQuery, IEnumerable<ClassroomDto>>
{
    public async Task<IEnumerable<ClassroomDto>> Handle(GetAllClassroomsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("getting all classrooms");
        var classrooms = await classroomsRepository.GetAllAsync();
        var classroomsDto = mapper.Map<IEnumerable<ClassroomDto>>(classrooms);

        return classroomsDto;
    }
}