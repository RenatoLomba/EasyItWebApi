using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityMapping
{
    public class TestimonialMap : IEntityTypeConfiguration<TestimonialEntity>
    {
        public void Configure(EntityTypeBuilder<TestimonialEntity> builder)
        {
            builder.ToTable("Testimonial");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();

            builder.Property(u => u.Description).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(u => u.Stars).HasColumnType("DOUBLE(4,2)");
            builder.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow).HasColumnType("DATETIME");
            builder.Property(u => u.UpdateAt).HasColumnType("DATETIME");
            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.ExpertId).IsRequired();

            builder.HasOne(t => t.User).WithMany(u => u.Testimonials);
            builder.HasOne(t => t.Expert).WithMany(e => e.Testimonials);

        }
    }
}
