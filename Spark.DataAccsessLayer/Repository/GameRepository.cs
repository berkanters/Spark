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
    public class GameRepository : Repository<Question>, Core.IntRepository.IGameRepository
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
            var question = sparkDbContext.Questions.Include("Answer").ToListAsync();
            return (await question);
        }

        public async Task<Question> GetWithAnswersByIdAsync(Guid qId)
        {
            return (await _db.Questions.Include(s => s.Answers).FirstOrDefaultAsync(s => s.Id == qId))!;
        }
    }
}
