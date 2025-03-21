using MediatR;
using Application.Classrooms.Dtos;

namespace Application.Classrooms.Queries.GetAllClassrooms;
public class GetAllClassroomsQuery : IRequest<IEnumerable<ClassroomDto>>
{
}