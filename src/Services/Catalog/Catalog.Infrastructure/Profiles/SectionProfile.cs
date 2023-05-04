using AutoMapper;
using Catalog.Domain.Dtos.CrudDtos;
using Catalog.Domain.Dtos;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Profiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile() 
        {
            CreateMap<Section, SectionDto>().ReverseMap();
            CreateMap<Section, CreateSectionDto>().ReverseMap();
        }
    }
}
