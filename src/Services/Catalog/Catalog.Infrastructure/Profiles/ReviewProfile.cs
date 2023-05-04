using AutoMapper;
using Catalog.Domain.Dtos;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile() 
        {
            CreateMap<Review, ReviewDto>();
        }
    }
}
