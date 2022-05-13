using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.IntRepository;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private SparkDBContext SparkDBContext
        {
            get => _db as SparkDBContext;
        }

        public UserRepository(SparkDBContext db) : base(db)
        {
        }

        public async Task<IEnumerable<User>> GetUserByGenderAndAge(string gender, short age)
        {
            return (await SparkDBContext.)
        }
    }
}
