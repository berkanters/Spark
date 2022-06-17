using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntRepository
{
    public interface IGameRepository: IRepository<Question>
    {
        Task<IEnumerable<Question>>GetAllWithAnswersAsync();
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<Question> GetWithAnswersByIdAsync(Guid qId);
        //Task<Question> GetWithAnswersAndUserAnswerByIdAsync(Guid qId);

        Task<List<Answer>> GetFakeAnswers(Guid questId, Guid userId);

    }
}
