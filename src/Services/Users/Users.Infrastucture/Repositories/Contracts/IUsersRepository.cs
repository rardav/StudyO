using Users.Domain.Dtos;
using Users.Domain.Entities;

namespace Users.Infrastucture.Repositories.Contracts
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAll();
    }
}
