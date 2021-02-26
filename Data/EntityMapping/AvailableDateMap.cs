using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityMapping
{
    public class AvailableDateMap : IEntityTypeConfiguration<AvailableDateEntity>
    {
        public void Configure(EntityTypeBuilder<AvailableDateEntity> builder)
        {
            builder.ToTable("AvailableDate");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();

            builder.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow).HasColumnType("DATETIME");
            builder.Property(u => u.UpdateAt).HasColumnType("DATETIME");
            builder.Property(u => u.Day).IsRequired().HasColumnType("INT");
            builder.Property(u => u.Month).IsRequired().HasColumnType("INT");
            builder.Property(u => u.Year).IsRequired().HasColumnType("INT");
            builder.Property(u => u.ExpertId).IsRequired();

            builder.HasOne(u => u.Expert).WithMany(e => e.AvailableDates);
        }
    }
}
