namespace Application.StudentAttendances.Dtos
{
    using AutoMapper;
    using Domain.Entities;
    using Application.StudentAttendances.Commands.CreateAttendance;

    public class StudentAttendanceProfile : Profile
    {
        public StudentAttendanceProfile()
        {
            CreateMap<CreateStudentAttendanceCommand, StudentAttendance>();
        }
    }

}

