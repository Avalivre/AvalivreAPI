using Avalivre.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avalivre.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users")
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .HasColumnName("USR_Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(u => u.Name)
                .HasColumnName("USR_Name")
                .HasMaxLength(256)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasColumnName("USR_Email")
                .HasMaxLength(256)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .HasColumnName("USR_Password")
                .HasMaxLength(256)
                .IsRequired();

            builder
                .Property(u => u.IsAdmin)
                .HasColumnName("USR_IsAdmin")
                .IsRequired();
        }
    }
}
