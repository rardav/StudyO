using AutoMapper;
using Catalog.Domain.Dtos.CrudDtos;
using Catalog.Domain.Entities;
using StudyO.Courses.Domain.Dtos;

namespace Catalog.Infrastructure.Profiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile() 
        { 
            CreateMap<Lesson, CreateLessonDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
        }
    }
}
