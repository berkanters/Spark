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
        private readonly IRepository<User> _repo;
        public readonly IUnitOfWork _unit;
        public UserService(IUnitOfWork unit, IRepository<User> repo) : base(unit, repo)
        {
            _unit = unit;
            _repo = repo;
        }

        public async Task<IEnumerable<User>> GetUserByGenderAndAge(string gender, short minAge, short maxAge)
        {
            return await _unit.User.GetUserByGenderAndAge(gender, minAge, maxAge);
        }

        public double CalculateDistance(Guid user1Id, Guid user2Id)
        {
            return _unit.User.CalculateDistance(user1Id, user2Id);
        }
    }

}
