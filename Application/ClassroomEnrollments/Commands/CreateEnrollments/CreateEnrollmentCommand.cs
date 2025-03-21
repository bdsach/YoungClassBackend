using MediatR;
using Application.ClassroomEnrollments.Dtos;

namespace Application.Classrooms.Commands.CreateEnrollments;

public class CreateEnrollmentCommand : IRequest<int>
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public int ClassroomId { get; set; }
}