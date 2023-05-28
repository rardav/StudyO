using AutoMapper;
using Users.Domain.Dtos;
using Users.Domain.Dtos.CrudDtos;
using Users.Domain.Entities;

namespace Users.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
        }

    }
}
