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
            var checkMyLike = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.UserId == id && x.LikedUserId == lId).Result;
            if (checkLike == null && checkMyLike == null)
            {
                entity.UserId = id;
                entity.LikedUserId = lId;
                _dbSet.AddAsync(entity);
            }
            else if (checkMyLike !=null )
            {
                
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
            var match1 = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.LikedUserId == id && x.UserId == lId&&x.IsMatch==true).Result;
            var match2 = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.UserId == id && x.LikedUserId == lId && x.IsMatch == true).Result;
            if (match1 != null)
            {
                sparkDBContext.Likes.Remove(match1);
            }
            else if (match2 != null)
            {
                sparkDBContext.Likes.Remove(match2);
            }
        }

        public void ScoreUp(Guid id1, Guid id2, int score)
        {
            var match1 = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.UserId == id1 && x.LikedUserId == id2 && x.IsMatch == true).Result;
            var match2 = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.LikedUserId == id1 && x.UserId == id2 && x.IsMatch == true).Result;
            if (match1 != null)
            {
                match1.User1Score = score;
                sparkDBContext.Likes.Update(match1);
            }
            else if (match2 != null)
            {
                match2.User2Score = score;
                sparkDBContext.Likes.Update(match2);
            }
        }

        public bool IsThereAnyWin(Guid id1, Guid id2)
        {
            var checkWin1 = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.UserId == id1 && x.LikedUserId == id2&& x.IsMatch == true).Result;
            var checkWin2 = sparkDBContext.Likes.FirstOrDefaultAsync(x => x.LikedUserId == id1 && x.UserId == id2 && x.IsMatch == true).Result;

            if (checkWin1 != null)
            {
                if (checkWin1.User1Score == null || checkWin1.User2Score == null)
                {
                    return false;
                }
               
                else if (checkWin1.User1Score + checkWin1.User2Score >= 10)
                {
                    checkWin1.IsWin = true;
                    sparkDBContext.Likes.Update(checkWin1);
                    return true;
                }
                else if (checkWin1.User1Score>0&& checkWin1.User2Score>0&&(checkWin1.User1Score + checkWin1.User2Score < 10))
                {
                    sparkDBContext.Likes.Remove(checkWin1);
                    return false;
                }
                
            }
            else if (checkWin2 != null)
            {
                if (checkWin2.User1Score == null || checkWin2.User2Score == null)
                {
                    return false;
                }
                else if (checkWin2.User1Score + checkWin2.User2Score >= 10)
                {
                    checkWin2.IsWin = true;
                    sparkDBContext.Likes.Update(checkWin2);
                    return true;
                }
                else if (checkWin2.User1Score > 0 && checkWin2.User2Score > 0 && (checkWin2.User1Score + checkWin2.User2Score < 10))
                {
                    sparkDBContext.Likes.Remove(checkWin2);
                    return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Like>> GetAllMyMatches(Guid id)
        {
            return await sparkDBContext.Likes.Where(x =>( x.UserId == id|| x.LikedUserId==id) && x.IsMatch == true).ToListAsync();
        }
    }
}
