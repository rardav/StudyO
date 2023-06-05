using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Users.Domain.Dtos;
using Users.Domain.Dtos.CrudDtos;
using Users.Domain.Entities;
using Users.Infrastucture.Contexts;
using Users.Infrastucture.Repositories.Contracts;

namespace Users.Infrastucture.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private UsersContext _dbContext { get; set; }

        public UsersRepository(UsersContext dbContext)
        {
            _dbContext = dbContext;
        }

        Task<IEnumerable<UserDto>> IUsersRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                Email = registerDto.Email.ToLower(),
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                DateOfRegister = DateTime.UtcNow
            };

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public Task<User> GetAsync(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));

            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Email.Equals(email));

            return user;
        }
    }
}
