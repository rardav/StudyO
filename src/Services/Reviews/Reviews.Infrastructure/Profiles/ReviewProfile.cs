using AutoMapper;
using Reviews.Domain.Dtos;
using Reviews.Domain.Dtos.CrudDtos;
using Reviews.Domain.Entities;

namespace Reviews.Infrastructure.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<ReviewDto, CreateReviewDto>().ReverseMap();
        }
    }
}
