
namespace Application.StudentAttendances.Commands.CreateAttendance
{
    using MediatR;
    using AutoMapper;
    using Application.Users;
    using Microsoft.Extensions.Logging;
    using Domain.Entities;
    using Application.Interfaces.Repositories;

    public class CreateStudentAttendanceCommandHandler(ILogger<CreateStudentAttendanceCommandHandler> logger,
    IMapper mapper,
    IStudentAttendanceRepository studentAttendanceRepository,
    IUserContext userContext) : IRequestHandler<CreateStudentAttendanceCommand, int>
    {
        public async Task<int> Handle(CreateStudentAttendanceCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();

            if (currentUser is null)
            {
                logger.LogError("No authenticated user found while attempting to create a StudentAttendance.");
                throw new InvalidOperationException("Cannot Create StudentAttendance without an authenticated user.");
            }

            logger.LogInformation("{UserName} [{UserId}] Creating a new StudentAttendance {@Classroom}",
                currentUser.Email,
                currentUser.Id,
                request);

            var studentAttendance = mapper.Map<StudentAttendance>(request);
            studentAttendance.DateUTC = DateTime.UtcNow;
            studentAttendance.CreatedUTC = DateTime.UtcNow;
            studentAttendance.UpdatedUTC = DateTime.UtcNow;
            studentAttendance.ClassroomId = request.ClassroomId;

            var id = await studentAttendanceRepository.Create(studentAttendance);

            return id;
        }
    }
}
