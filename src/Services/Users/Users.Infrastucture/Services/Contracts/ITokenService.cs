using Users.Domain.Entities;

namespace Users.Infrastucture.Services.Contracts
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
