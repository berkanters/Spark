﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spark.Core.Models;

namespace Spark.DataAccsessLayer.Seed
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    LastName = "Admin",
                    Email = "admin@iea.com",
                    Age = 20,
                    Password = "123456",
                    IsAdmin = true,
                    IsActive = true,
                    IsDelete = false,
                    Phone = "05362454497",
                    Gender = "Man"

                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kaan",
                    LastName = "Gürbüz",
                    Email = "kaangurbuz97@gmail.com",
                    Age = 25,
                    Password = "123456",
                    IsAdmin = true,
                    IsActive = true,
                    IsDelete = false,
                    Phone = "05394643458",
                    Gender = "Man"

                });
        }
    }
}
