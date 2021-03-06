using System;
using System.Collections.Generic;
using System.Text;
using Data.EntityMapping;
using Data.Seeds;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<ExpertEntity>(new ExpertMap().Configure);
            modelBuilder.Entity<ServiceEntity>(new ServiceMap().Configure);
            modelBuilder.Entity<PhotoEntity>(new PhotoMap().Configure);
            modelBuilder.Entity<TestimonialEntity>(new TestimonialMap().Configure);
            modelBuilder.Entity<AppointmentEntity>(new AppointmentMap().Configure);
            modelBuilder.Entity<AvailableDateEntity>(new AvailableDateMap().Configure);
            modelBuilder.Entity<AvailableHourEntity>(new AvailableHourMap().Configure);
            modelBuilder.Entity<FavoritesEntity>(new FavoritesMap().Configure);

            UserSeed.Users(modelBuilder);
            //ExpertSeed.Experts(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ExpertEntity> Experts { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<TestimonialEntity> Testimonials { get; set; }
        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<AvailableDateEntity> AvailableDates { get; set; }
        public DbSet<AvailableHourEntity> AvailableHours { get; set; }
        public DbSet<FavoritesEntity> Favorites { get; set; }
    }
}