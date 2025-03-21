using AutoMapper;
using Domain.Entities;
using Application.Classrooms.Commands.CreateEnrollments;

namespace Application.ClassroomEnrollments.Dtos;

public class ClassroomEnrollmentProfile : Profile
{
    public ClassroomEnrollmentProfile()
    {
        CreateMap<CreateEnrollmentCommand, ClassroomEnrollment>();
        CreateMap<ClassroomEnrollment, ClassroomEnrollmentDto>();
    }
}