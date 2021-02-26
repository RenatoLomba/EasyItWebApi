using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityMapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(u => u.Role).IsRequired().HasDefaultValue("User").HasMaxLength(45).HasColumnType("VARCHAR(45)");
            builder.Property(u => u.Password).HasMaxLength(200).HasColumnType("VARCHAR(200)");
            builder.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow).HasColumnType("DATETIME");
            builder.Property(u => u.UpdateAt).HasColumnType("DATETIME");
            builder.Property(u => u.Avatar).HasMaxLength(500).HasColumnType("VARCHAR(500)");
        }
    }
}
