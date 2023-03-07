using AutoMapper;
using StudyO.Courses.Domain.Dtos;
using StudyO.Courses.Domain.Entities;

namespace StudyO.Courses.Infrastructure.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<CourseDto, CreateCourseDto>().ReverseMap();
        }
    }
}
