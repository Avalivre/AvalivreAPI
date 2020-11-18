using Avalivre.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avalivre.Infrastructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("Products")
                .HasKey(u => u.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("PRD_Id")
                .IsRequired();

            builder
                .Property(p => p.CreationDate)
                .HasColumnName("PRD_CreationDate")
                .IsRequired();

            builder
                .Property(p => p.UpdateDate)
                .HasColumnName("PRD_UpdateDate");

            builder
                .Property(p => p.Name)
                .HasColumnName("PRD_Name")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Brand)
                .HasColumnName("PRD_Brand")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.ModelCode)
                .HasColumnName("PRD_ModelCode")
                .HasMaxLength(30);

            builder
                .Property(p => p.Material)
                .HasColumnName("PRD_Material")
                .HasMaxLength(30);
        }
    }
}
