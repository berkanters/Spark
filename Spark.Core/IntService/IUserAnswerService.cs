using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntService
{
    public interface IUserAnswerService:IService<UserAnswer>
    {
        Task<UserAnswer> ChooseAnswer(Guid uId, Guid aId,Guid qId);
        Task<UserAnswer> GetUserAnswer(Guid uId, Guid qId);
    }
}
