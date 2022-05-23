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
    public class ChatService:Service<Chat>,IChatService
    {
        private readonly IRepository<Chat> _repo;
        public readonly IUnitOfWork _unit;
        public ChatService(IUnitOfWork unit, IRepository<Chat> repo) : base(unit, repo)
        {
            _repo = repo;
            _unit = unit;
        }

        public async Task<IQueryable<Chat>> GetMessagesBetween2Person(Guid id, Guid id2)
        {
            return await _unit.Chat.GetMessagesBetween2Person(id, id2);
            
        }
    }
}
