using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityMapping
{
    public class PhotoMap : IEntityTypeConfiguration<PhotoEntity>
    {
        public void Configure(EntityTypeBuilder<PhotoEntity> builder)
        {
            builder.ToTable("Photo");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(u => u.Url).IsRequired().HasMaxLength(225).HasColumnType("VARCHAR(225)");
            builder.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow).HasColumnType("DATETIME");
            builder.Property(u => u.UpdateAt).HasColumnType("DATETIME");

            builder.HasOne(e => e.Expert).WithMany(s => s.Photos);
        }
    }
}
