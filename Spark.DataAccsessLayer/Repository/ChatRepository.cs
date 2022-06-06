using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.IntRepository;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Repository
{
    public class ChatRepository:Repository<Chat>,IChatRepository
    {
        public SparkDBContext sparkDBContext
        {
            get => _db as SparkDBContext;
        }
        public ChatRepository(SparkDBContext db) : base(db)
        {
        }

        public Task<IQueryable<Chat>> GetMessagesBetween2Person(Guid id, Guid id2)
        {
            //var check = sparkDBContext.Likes.FirstOrDefault(c => c.UserId == id && c.LikedUserId == id2&&c.IsWin==true);
            
            var messages = sparkDBContext.Chats.Where(x =>
                x.User1Id == id && x.User2Id == id2 || x.User1Id == id2 && x.User2Id == id);
            return Task.FromResult(messages);
        }
    }
}
