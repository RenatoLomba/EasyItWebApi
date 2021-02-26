using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Data.Seeds
{
    public class ExpertSeed
    {
        public static void Experts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpertEntity>().HasData(
                new ExpertEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Bonyek Lacerda",
                    Email = "bonyec_lacerda@b7web.com.br",
                    Role = "User",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = null,
                    Password = "mudar123",
                    Avatar = "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/avatar1.png",
                    Stars = 4.6,
                    Location = "São Paulo"
                },
                new ExpertEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Marisha Ray",
                    Email = "marisha_ray@critrole.com",
                    Role = "User",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = null,
                    Password = "mudar123",
                    Avatar = "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/avatar2.png",
                    Stars = 3.7,
                    Location = "São Paulo"
                },
                new ExpertEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Johnny Silverhand",
                    Email = "johnny_silverhand@cyberpunk.com",
                    Role = "User",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = null,
                    Password = "mudar123",
                    Avatar = "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/avatar3.png",
                    Stars = 2.4,
                    Location = "São Paulo"
                },
                new ExpertEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Ozzy Osbourne",
                    Email = "ozzy_ironman@blacksabbath.com",
                    Role = "User",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = null,
                    Password = "mudar123",
                    Avatar = "C:/Users/adm/Documents/GitHub/EasyIt/EasyItMobileApp/src/avatars/ozzy_avatar.jpg",
                    Stars = 5.0,
                    Location = "São Paulo"
                }
            );
        }
    }
}
