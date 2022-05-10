using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntRepository
{
    public interface IAnswerRepository:IRepository<UserAnswer>
    {
        Task<UserAnswer> GetUserAnswerWithQuestionId(Guid id);
    }
}
