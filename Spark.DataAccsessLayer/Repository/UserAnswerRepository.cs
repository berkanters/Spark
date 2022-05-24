using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.IntRepository;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Repository
{
    public class UserAnswerRepository : Repository<UserAnswer>, IUserAnswerRepository
    {

        public SparkDBContext sparkDBContext
        {
            get => _db as SparkDBContext;
        }
        public UserAnswerRepository(SparkDBContext db) : base(db)
        {
        }

        public  void ChooseAnswer(Guid uId, Guid aId,Guid qId)
        {
            sparkDBContext.UserAnswers.Add(new UserAnswer()
            {
                UserId = uId,
                AnswerId = aId,
                QuestionId = qId
            });
            
        }

        public async Task<UserAnswer> GetUserAnswerByQuestion(Guid uId, Guid qId)
        {
            var question = sparkDBContext.UserAnswers.FirstOrDefaultAsync(s => s.Answer.QuestionId == qId && s.UserId == uId);
            return (await question)!;
        }
    }
}
