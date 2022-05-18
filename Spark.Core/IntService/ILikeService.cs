using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntService
{
    public interface ILikeService:IService<Like>
    {
        Task<Like> PostUserByID(Guid id, Guid lId, Like entity);
    }
}
