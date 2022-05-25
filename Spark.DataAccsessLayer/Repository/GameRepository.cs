using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.IntRepository;
using Spark.Core.Models;

namespace Spark.DataAccessLayer.Repository
{
    public class GameRepository : Repository<Question>, IGameRepository
    {
        private SparkDBContext sparkDbContext
        {
            get => _db as SparkDBContext;
        }

        public GameRepository(SparkDBContext db) : base(db)
        {

        }

        public async Task<IEnumerable<Question>> GetAllWithAnswersAsync()
        {
            var question = sparkDbContext.Questions.Include(s=>s.Answers).ToListAsync();
            return (await question);
        }

        public async Task<Question> GetWithAnswersByIdAsync(Guid qId)
        {
            return (await _db.Questions.Include(s => s.Answers).FirstOrDefaultAsync(s => s.Id == qId))!;
        }

        public async Task<List<Answer>> GetFakeAnswers(Guid questId, Guid userId)
        {
            
            
            var userAnswer = sparkDbContext.UserAnswers.FirstOrDefaultAsync(s => s.User.Id == userId && s.Question.Id == questId).Result;
            var fakeAnswers = sparkDbContext.Answers.Where(s => s.Question.Id == questId && s.Id != userAnswer!.AnswerId).ToList();
            int[] ansRandom = new int[3];


            do
            {
                ansRandom[0] = new Random().Next(0, fakeAnswers.Count);
                ansRandom[1] = new Random().Next(0, fakeAnswers.Count);
                ansRandom[2] = new Random().Next(0, fakeAnswers.Count);
            } while ((ansRandom[0] == ansRandom[1]) || (ansRandom[1] == ansRandom[2]) || (ansRandom[0] == ansRandom[2]));

            List<Answer> fakeAns = new List<Answer>();
            for (int i = 0; i < 3; i++)
            {
                fakeAns.Add(fakeAnswers[ansRandom[i]]);
            }
            return fakeAns;
        }
    }
}
