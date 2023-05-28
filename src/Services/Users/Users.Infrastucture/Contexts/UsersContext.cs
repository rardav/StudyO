using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;

namespace Users.Infrastucture.Contexts
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
