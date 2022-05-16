using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.IntRepository;
using Spark.Core.IntService;
using Spark.Core.IntUnitOfWork;
using Spark.Core.Models;

namespace Spark.Services.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUnitOfWork unit, IRepository<User> repo) : base(unit, repo)
        {
        }

        public async Task<IEnumerable<User>> GetUserByGenderAndAge(string gender, short minAge, short maxAge)
        {
            return await _unit.User.GetUserByGenderAndAge(gender, minAge, maxAge);
        }
    }

}
