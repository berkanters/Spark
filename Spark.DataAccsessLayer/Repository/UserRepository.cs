using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<User>> GetUserByGenderAndAge(string gender, short minAge,short maxAge)
        {
            var user = sparkDBContext.Users.Where(x => x.Gender == gender && x.Age >= minAge && x.Age <= maxAge)
                .ToListAsync();
            return (await user);
        }
    }
}
