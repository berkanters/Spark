using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Spark.Core.IntRepository;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public SparkDBContext sparkDBContext
        {
            get => _db as SparkDBContext;
        }

        public UserRepository(SparkDBContext db) : base(db)
        {
        }

        public async Task<IEnumerable<User>> GetUserByGenderAndAge(string gender, int minAge,int maxAge,int distance, Guid user1)
        {
            var user = sparkDBContext.Users.Where(x => x.Gender == gender && x.Age >= minAge && x.Age <= maxAge&&x.Id!=user1);
            var undoUser1 = sparkDBContext.Likes.Where(x => x.UserId == user1).Select(x=>x.LikedUser);
            var undoUser2 = sparkDBContext.Likes.Where(x => x.LikedUserId == user1).Select(x => x.User);
            IList<User> filter= new List<User>();
            
                foreach (var i in user)
                {

                    if ((int)CalculateDistance(user1, i.Id) < distance)
                    {
                        filter.Add(i);
                    }

                }

                foreach (var i in undoUser1)
                {
                    filter.Remove(i);
                }

                foreach (var i in undoUser2)
                {
                    filter.Remove(i);
                }
                return (filter);
        }

        public double CalculateDistance(Guid user1Id, Guid user2Id)
        {
            var user1 = sparkDBContext.Users.FirstOrDefault(x => x.Id == user1Id);
            var user2 = sparkDBContext.Users.FirstOrDefault(x => x.Id == user2Id);
            //Math.PI* usr1Lat / 180;
            double usr1Lat = Math.PI * user1.Latitude / 180;
            double usr1Lon = Math.PI * user1.Longitude / 180;
            double usr2Lat = Math.PI * user2.Latitude / 180;
            double usr2Lon = Math.PI * user2.Longitude / 180;

            double dLon = usr2Lon - usr1Lon;
            double dLat = usr2Lat - usr1Lat;

            double a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(usr1Lat) * Math.Cos(usr2Lat) * Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Asin(Math.Sqrt(a));
            double r = 6371;
            double d = c * r;
            return d;
        }

        public void SetLocation(Guid userId, double latitude, double longitude)
        {
            var user = sparkDBContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null) return;
            user.Latitude = latitude;
            user.Longitude = longitude;
        }

        public void SetImagePath(Guid userId, string imagePath)
        {
            var user = sparkDBContext.Users.FirstOrDefault(x => x.Id == userId);
            user.ImagePath = imagePath;
        }
    }
}
