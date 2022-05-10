using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntRepository
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<User>> GetUserByGenderAndAge(string gender,short age);
        Task<IEnumerable<Status>> GetUserByStatusId(Guid id);
    }
}
