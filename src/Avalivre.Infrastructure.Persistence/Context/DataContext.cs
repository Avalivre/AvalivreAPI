using Avalivre.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Avalivre.Infrastructure.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
