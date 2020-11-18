using Avalivre.Domain.Products;
using Avalivre.Domain.Users;
using Avalivre.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Avalivre.Infrastructure.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
