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

        public Task<IQueryable<User>> GetMyWinMatches(Guid id)
        {
            //var check = sparkDBContext.Likes.Where(c => (c.UserId == id || c.LikedUserId == id) && c.IsWin == true);
            var users = sparkDBContext.Likes.Where(x => (x.UserId == id && x.LikedUserId != id)&&x.IsMatch==true).Select(x => x.LikedUser);
            var users2 = sparkDBContext.Likes.Where(x => (x.UserId != id && x.LikedUserId == id) && x.IsMatch == true).Select(x => x.User);
            var winMatches = users.Concat(users2);
            return Task.FromResult(winMatches);
        }

        public  string GetLastMessage(Guid id,Guid id2)
        {
            var lastMessage = sparkDBContext.Chats.Where(x =>
                (x.User1Id == id && x.User2Id == id2) || (x.User1Id == id2 && x.User2Id == id)).OrderByDescending(x=>x.MessageDate).FirstOrDefault();
            if (lastMessage == null)
                return "You have never chat before !";
            return lastMessage!.MessageText!;
        }
    }
}
