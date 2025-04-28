using AutoMapper;
using Domain.Entities;
using Application.Classrooms.Commands.CreateClassroom;

namespace Application.Classrooms.Dtos;
public class ClassroomProfile : Profile
{
    public ClassroomProfile()
    {
        CreateMap<CreateClassroomCommand, Classroom>();
        CreateMap<Classroom, ClassroomDto>()
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => 
                src.Enrollments.Select(e => new StudentDto
                {
                    Id = e.Student.Id,
                    StudentId = e.Student.StudentProfile != null ? e.Student.StudentProfile.StudentId : "",
                    FirstName = e.Student.StudentProfile != null ? e.Student.StudentProfile.FirstName : "",
                    LastName = e.Student.StudentProfile != null ? e.Student.StudentProfile.LastName : ""
                })
            ));
    }
}