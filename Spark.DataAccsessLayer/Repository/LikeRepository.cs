using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.IntRepository;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Repository
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public SparkDBContext sparkDbContext
        {
            get => _db as SparkDBContext;
        }
        public LikeRepository(SparkDBContext db) : base(db)
        {
        }


        public async Task<Like> PostUserByID(Guid id, Guid lId, Like entity)
        {
            return null;
        }

        public Task<Like> GetByLikeID(Guid id, Guid lId)
        {
            throw new NotImplementedException();
        }

        public Like UpdateByLike(Like entity)
        {
            throw new NotImplementedException();
        }
    }
}
