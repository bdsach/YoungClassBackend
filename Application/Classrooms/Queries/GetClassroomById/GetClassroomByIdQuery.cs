using MediatR;
using Application.Classrooms.Dtos;

namespace Application.Classrooms.Queries.GetClassroomById;

public class GetClassroomByIdQuery(int id) : IRequest<ClassroomDto>
{
    public int Id { get; set; } = id;
}