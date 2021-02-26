using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Data.Seeds
{
    public class UserSeed
    {
        public static void Users(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "adm@root.com",
                    Role = "Administrator",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = null,
                    Password = "mudar123",
                    Avatar = "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/admAvatar.png",
                }
            );
        }
    }
}
