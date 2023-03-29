using AutoMapper;
using Classes.Domain.Dtos;
using Classes.Domain.Entities;

namespace StudyO.Classes.Infrastructure.Profiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Class, CreateClassDto>().ReverseMap();
            CreateMap<Class, UpdateClassDto>().ReverseMap();
        }
        
    }
}
