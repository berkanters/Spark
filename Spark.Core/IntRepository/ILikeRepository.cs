using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntRepository
{
    public interface ILikeRepository : IRepository<Like>
    {
        Task<Like> PostUserByID(Guid id, Guid lId,Like entity);
        Task<Like> GetByLikeID(Guid id, Guid lId);

        Like UpdateByLike(Like entity);

    }
}
