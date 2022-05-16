using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntService
{
    public interface IUserService : IService<User>
    {
        Task<IEnumerable<User>> GetUserByGenderAndAge(string gender, short minAge, short maxAge);
    }
}
