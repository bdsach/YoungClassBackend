using MediatR;

namespace Application.Classrooms.Commands.CreateClassroom;

public class CreateClassroomCommand : IRequest<int>
{
    public string Subject { get; set; } = default!;
    public string GradeLevel { get; set; } = default!;
    public string Room { get; set; } = default!;
    public string SubjectGroup { get; set; } = default!;
}