using AutoMapper;
using Catalog.Domain.Dtos;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Profiles
{
    public class FaqProfile : Profile
    {
        public FaqProfile() 
        {
            CreateMap<Faq, FaqDto>().ReverseMap();
        }
    }
}
