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

        public bool IsThereAnyMatch(Guid id, Guid lId)
        {
            var checkLike = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.LikedUserId == id && x.UserId == lId&&x.IsMatch==true).Result;
            if (checkLike == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RemoveMatch(Guid id, Guid lId)
        {
            var match1 = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.LikedUserId == id && x.UserId == lId).Result;
            var match2 = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.UserId == id && x.LikedUserId == lId).Result;
            if (match1 != null)
            {
                sparkDBContext.Likes.Remove(match1);
            }
            else if (match2 != null)
            {
                sparkDBContext.Likes.Remove(match2);
            }
        }
    }
}
