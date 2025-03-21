namespace Application.StudentAttendance.Dtos
{
    using AutoMapper;
    using Domain.Entities;
    using Application.StudentAttendance.Commands.CreateAttendance;

    public class StudentAttendanceProfile : Profile
    {
        public StudentAttendanceProfile()
        {
            CreateMap<CreateStudentAttendanceCommand, StudentAttendance>();
        }
    }

}

