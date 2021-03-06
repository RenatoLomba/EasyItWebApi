﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210215000220_MigrationUserAvatarLenght")]
    partial class MigrationUserAvatarLenght
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.ExpertEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Avatar")
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2021, 2, 15, 0, 2, 20, 183, DateTimeKind.Utc).AddTicks(2201));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Location")
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(45)")
                        .HasMaxLength(45)
                        .HasDefaultValue("User");

                    b.Property<double>("Stars")
                        .HasColumnType("DOUBLE(4,2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Expert");
                });

            modelBuilder.Entity("Domain.Entities.ServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2021, 2, 15, 0, 2, 20, 185, DateTimeKind.Utc).AddTicks(8738));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("ExpertId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)")
                        .HasMaxLength(60);

                    b.Property<double>("Price")
                        .HasColumnType("DOUBLE(10,2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ExpertId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Avatar")
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2021, 2, 15, 0, 2, 20, 180, DateTimeKind.Utc).AddTicks(8784));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(45)")
                        .HasMaxLength(45)
                        .HasDefaultValue("User");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fcdb180b-3904-4732-a903-93010f940e4d"),
                            Avatar = "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png",
                            CreateAt = new DateTime(2021, 2, 15, 0, 2, 20, 190, DateTimeKind.Utc).AddTicks(985),
                            Email = "adm@root.com",
                            Name = "Administrador",
                            Password = "mudar123",
                            Role = "Administrator"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ServiceEntity", b =>
                {
                    b.HasOne("Domain.Entities.ExpertEntity", "Expert")
                        .WithMany("Services")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
