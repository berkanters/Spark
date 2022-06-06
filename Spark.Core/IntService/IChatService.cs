using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntService
{
    public interface IChatService:IService<Chat>
    {
        Task<IQueryable<Chat>> GetMessagesBetween2Person(Guid id, Guid id2);
        Task<IQueryable<User>> GetMyWinMatches(Guid id);
        string GetLastMessage(Guid id, Guid id2);
    }
}
