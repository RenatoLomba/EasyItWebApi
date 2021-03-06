using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityMapping
{
    public class FavoritesMap : IEntityTypeConfiguration<FavoritesEntity>
    {
        public void Configure(EntityTypeBuilder<FavoritesEntity> builder)
        {
            builder.ToTable("Favorites");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();

            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.ExpertId).IsRequired();
            builder.Property(u => u.CreateAt).HasDefaultValue(DateTime.UtcNow).HasColumnType("DATETIME");
            builder.Property(u => u.UpdateAt).HasColumnType("DATETIME");

            builder.HasOne(u => u.User).WithMany(u => u.Favorites);
            builder.HasOne(u => u.Expert).WithMany(u => u.Favorites);
        }
    }
}
