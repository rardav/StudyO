using AutoMapper;
using Classes.Domain.Dtos;
using Classes.Domain.Entities;

namespace Classes.Infrastructure.Profiles
{
    public class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            CreateMap<CreateAssignmentDto, Assignment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<AssignmentDto, Assignment>().ReverseMap();
        }
    }
}
