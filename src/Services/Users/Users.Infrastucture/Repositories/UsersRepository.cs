using Microsoft.EntityFrameworkCore;
using Users.Domain.Dtos;
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

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
