using AutoMapper;
using ProgressTracking.Domain.Dtos;
using ProgressTracking.Domain.Entities;

namespace ProgressTracking.Infrastructure.Profiles
{
    public class ProgressProfile : Profile
    {
        public ProgressProfile()
        {
            CreateMap<Progress, ProgressDto>().ReverseMap();
        }
    }
}
