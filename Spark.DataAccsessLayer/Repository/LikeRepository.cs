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
        public SparkDBContext sparkDBContext
        {
            get => _db as SparkDBContext;
        }
        public LikeRepository(SparkDBContext db) : base(db)
        {
        }


        public void MatchUsersWithUserIDs(Guid id, Guid lId)
        {
            Like entity = new Like();
            var checkLike = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.LikedUserId == id && x.UserId == lId).Result;
            if (checkLike == null)
            {
                entity.UserId = id;
                entity.LikedUserId = lId;
                _dbSet.AddAsync(entity);
            }
            else
            {
                entity = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.LikedUserId == id && x.UserId == lId).Result;
                entity.IsMatch = true;
                _dbSet.Update(entity);
            }
        }
    }
}
