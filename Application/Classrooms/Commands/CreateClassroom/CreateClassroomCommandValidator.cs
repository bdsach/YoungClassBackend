using FluentValidation;

namespace Application.Classrooms.Commands.CreateClassroom;

public class CreateClassroomCommandValidator : AbstractValidator<CreateClassroomCommand>
{
    public CreateClassroomCommandValidator()
    {
        RuleFor(dto => dto.Subject)
            .Length(3, 100);
        RuleFor(dto => dto.Room);
        RuleFor(dto => dto.GradeLevel);
        RuleFor(dto => dto.SubjectGroup)
            .Length(3, 100);
    }
}