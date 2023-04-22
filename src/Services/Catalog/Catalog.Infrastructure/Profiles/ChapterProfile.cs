using AutoMapper;
using Catalog.Domain.Dtos;
using Catalog.Domain.Dtos.CrudDtos;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Profiles
{
    public class ChapterProfile : Profile
    {
        public ChapterProfile() 
        {
            CreateMap<CreateChapterDto, Chapter>().ReverseMap();
            CreateMap<ChapterDto, Chapter>().ReverseMap();
        }
    }
}
