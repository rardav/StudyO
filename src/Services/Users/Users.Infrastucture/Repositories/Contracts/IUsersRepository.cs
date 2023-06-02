using Users.Domain.Dtos;
using Users.Domain.Dtos.CrudDtos;
using Users.Domain.Entities;

namespace Users.Infrastucture.Repositories.Contracts
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<User> Register(RegisterDto registerDto);
        Task<User> GetUserByEmail(string email);
        Task<bool> UserExists(string email);
    }
}
