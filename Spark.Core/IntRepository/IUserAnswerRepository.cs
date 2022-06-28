using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntRepository
{
    public interface IUserAnswerRepository : IRepository<UserAnswer>
    {
        void ChooseAnswer(Guid uId, Guid aId, Guid qId);
        Task<IQueryable<Answer>> GetUserAnswerByQuestion(Guid uId, Guid qId);
    }
}
