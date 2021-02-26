using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityMapping
{
    public class ExpertMap : IEntityTypeConfiguration<ExpertEntity>
    {
        public void Configure(EntityTypeBuilder<ExpertEntity> builder)
        {
            builder.ToTable("Expert");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(u => u.Role).IsRequired().HasDefaultValue("User").HasMaxLength(45).HasColumnType("VARCHAR(45)");
            builder.Property(u => u.Password).HasMaxLength(200).HasColumnType("VARCHAR(200)");
            builder.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow).HasColumnType("DATETIME");
            builder.Property(u => u.UpdateAt).HasColumnType("DATETIME");
            builder.Property(u => u.Avatar).HasMaxLength(500).HasColumnType("VARCHAR(500)");
            builder.Property(u => u.Location).HasMaxLength(100).HasColumnType("VARCHAR(100)");
            builder.Property(u => u.Stars).HasColumnType("DOUBLE(4,2)");
        }
    }
}
