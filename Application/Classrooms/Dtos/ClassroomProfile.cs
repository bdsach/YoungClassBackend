using AutoMapper;
using Domain.Entities;
using Application.Classrooms.Commands.CreateClassroom;

namespace Application.Classrooms.Dtos;
public class ClassroomProfile : Profile
{
    public ClassroomProfile()
    {
        CreateMap<CreateClassroomCommand, Classroom>();
        CreateMap<Classroom, ClassroomDto>();
    }
}