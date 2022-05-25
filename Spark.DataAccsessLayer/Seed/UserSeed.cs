using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Seed
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        //private readonly Guid[] _guids;
        //public UserSeed(Guid[] guids)
        //{
        //    _guids = guids;
        //}
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
                    IsDeleted = false,
                    Phone = "05362454497",
                    Gender = "Man",
                    Latitude = FakeData.NumberData.GetNumber(-90, 90),
                    Longitude = FakeData.NumberData.GetNumber(-180, 180)

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
                    IsDeleted = false,
                    Phone = "05394643458",
                    Gender = "Man",
                    Latitude = FakeData.NumberData.GetNumber(-90, 90),
                    Longitude = FakeData.NumberData.GetNumber(-180, 180)

                });
            for (int i = 0; i < 20; i++)
            {
                
                
                builder.HasData(
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = FakeData.NameData.GetFirstName(),
                        LastName = FakeData.NameData.GetSurname(),
                        Email = FakeData.NetworkData.GetEmail(),
                        Age = (short) FakeData.NumberData.GetNumber(18, 65),
                        Password = "123456",
                        IsAdmin = false,
                        IsActive = true,
                        IsDeleted = false,
                        Phone = FakeData.PhoneNumberData.GetPhoneNumber(),
                        Gender = "Man",
                        Latitude = FakeData.NumberData.GetNumber(-90,90),
                        Longitude = FakeData.NumberData.GetNumber(-180,180)
                    },
                new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = FakeData.NameData.GetFirstName(),
                        LastName = FakeData.NameData.GetSurname(),
                        Email = FakeData.NetworkData.GetEmail(),
                        Age = (short)FakeData.NumberData.GetNumber(18, 65),
                        Password = "123456",
                        IsAdmin = false,
                        IsActive = true,
                        IsDeleted = false,
                        Phone = FakeData.PhoneNumberData.GetPhoneNumber(),
                        Gender = "Woman",
                        Latitude = FakeData.NumberData.GetNumber(-90, 90),
                        Longitude = FakeData.NumberData.GetNumber(-180, 180)
                }
                    );
            }
        }
    }
}
