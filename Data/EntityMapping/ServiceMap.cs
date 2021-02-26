using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityMapping
{
    public class ServiceMap : IEntityTypeConfiguration<ServiceEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceEntity> builder)
        {
            builder.ToTable("Service");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Code).IsUnique();

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow).HasColumnType("DATETIME");
            builder.Property(u => u.UpdateAt).HasColumnType("DATETIME");
            builder.Property(u => u.Code).IsRequired().HasMaxLength(100).HasColumnType("VARCHAR(100)");
            builder.Property(u => u.Description).IsRequired().HasMaxLength(200).HasColumnType("VARCHAR(200)");
            builder.Property(u => u.Price).HasColumnType("DOUBLE(10,2)");

            // UM SERVICE POSSUI UM EXPERT (HAS ONE), E UM EXPERT POSSUI VARIOS SERVICES (WITH MANY)
            builder.HasOne(e => e.Expert).WithMany(s => s.Services);
        }
    }
}
