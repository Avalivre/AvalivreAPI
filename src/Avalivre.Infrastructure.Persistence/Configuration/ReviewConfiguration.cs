using Avalivre.Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avalivre.Infrastructure.Persistence.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .ToTable("Reviews")
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .HasColumnName("RVW_Id")
                .IsRequired();

            builder
                .Property(r => r.Description)
                .HasColumnName("RVW_Description")
                .HasColumnType("text")
                .IsRequired();

            builder
                .Property(r => r.Rating)
                .HasColumnName("RVW_Rating")
                .HasColumnType("tinyint")
                .IsRequired();

            builder
                .Property(r => r.UserProductImageUrl)
                .HasColumnName("RVW_UserProductImageUrl");


            builder
                .Property(r => r.CreationDate)
                .HasColumnName("RVW_CreationDate")
                .IsRequired();

            builder
                .Property(r => r.UpdateDate)
                .HasColumnName("RVW_UpdateDate");

            builder
                .Property(r => r.ProductId)
                .HasColumnName("RVW_ProductId")
                .IsRequired();

            builder
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.ProductId);

            builder
                .Property(r => r.UserId)
                .HasColumnName("RVW_UserId")
                .IsRequired();

            builder
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.UserId);
        }
    }
}
