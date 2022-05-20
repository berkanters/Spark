using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntRepository
{
    public interface IChatRepository:IRepository<Chat>
    {
        Task<IQueryable<Chat>> GetMessagesBetween2Person (Guid id,Guid id2);
    }
}
