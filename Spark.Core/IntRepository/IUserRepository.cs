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
        Task<IEnumerable<User>> GetUserByGenderAndAge(string gender,int minAge,int maxAge,int distance, Guid user1);

        double CalculateDistance(Guid user1Id, Guid user2Id);
        
        void SetLocation (Guid userId,double latitude,double longitude);

    }
}
