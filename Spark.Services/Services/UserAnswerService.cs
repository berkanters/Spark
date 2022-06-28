using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.IntRepository;
using Spark.Core.IntService;
using Spark.Core.IntUnitOfWork;
using Spark.Core.Models;

namespace Spark.Services.Services
{
    public class UserAnswerService : Service<UserAnswer>, IUserAnswerService
    {
        public readonly IUnitOfWork _unit;
        private readonly IRepository<UserAnswer> _repo;
        public UserAnswerService(IUnitOfWork unit,IRepository<UserAnswer> repo) : base(unit,repo)
        {
            _unit = unit;
            _repo = repo;
        }

        public async Task<UserAnswer> ChooseAnswer(Guid uId, Guid aId,Guid qId)
        {
            await _repo.AddAsync(new UserAnswer() { UserId = uId, AnswerId = aId, QuestionId = qId });
            await _unit.CommitAsync();
            return await _repo.GetByIdAsync(uId);
        }

        public async Task<IQueryable<Answer>> GetUserAnswer(Guid uId, Guid qId)
        {
            return await _unit.userAnswer.GetUserAnswerByQuestion(uId, qId);
        }
    }
}
