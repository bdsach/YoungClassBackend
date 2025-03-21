using MediatR;

namespace Application.Classrooms.Commands.CreateClassroom;

public class CreateClassroomCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
}