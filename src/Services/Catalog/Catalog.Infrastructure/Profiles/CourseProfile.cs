using AutoMapper;
using Catalog.Domain.Dtos;
using Catalog.Domain.Dtos.CrudDtos;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<CourseDto, CreateCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();
        }
    }
}
