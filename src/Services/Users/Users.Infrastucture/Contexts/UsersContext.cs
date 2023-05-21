using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;

namespace Users.Infrastucture.Contexts
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=usersdb;Username=admin;Password=admin1234;Database=UsersDb");
    }
}
