using MediatR;
using Application.ClassroomEnrollments.Dtos;

namespace Application.ClassroomEnrollments.Commands.BulkCreateEnrollments;

public class BulkCreateEnrollmentsCommand : IRequest<int>
{
    public List<BulkCreateEnrollmentsDto> Enrollments { get; set; } = [];
    public int ClassroomId { get; set; }
}
