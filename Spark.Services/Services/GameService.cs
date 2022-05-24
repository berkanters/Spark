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
    public class GameService : Service<Question>, IGameService
    {
        public GameService(IUnitOfWork unit, IRepository<Question> repo) :base(unit,repo)
        {
            
        }

            public async Task<IEnumerable<Question>> GetAllWithAnswersAsync()
            {
                var test = _unit.Game.GetAllWithAnswersAsync();
                return await test;
            }

            public async Task<Question> GetWithAnswersByIdAsync(Guid qId)
            {
                return await _unit.Game.GetWithAnswersByIdAsync(qId);
            }
        }
    }

