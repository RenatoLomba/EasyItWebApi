using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityMapping
{
    public class AvailableHourMap : IEntityTypeConfiguration<AvailableHourEntity>
    {
        public void Configure(EntityTypeBuilder<AvailableHourEntity> builder)
        {
            builder.ToTable("AvailableHour");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();

            builder.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow).HasColumnType("DATETIME");
            builder.Property(u => u.UpdateAt).HasColumnType("DATETIME");
            builder.Property(u => u.Hour).IsRequired().HasColumnType("INT");
            builder.Property(u => u.Minutes).IsRequired().HasColumnType("INT");
            builder.Property(u => u.AvailableDateId).IsRequired();

            builder.HasOne(u => u.AvailableDate).WithMany(e => e.AvailableHours);
        }
    }
}
