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
    public class LikeService:Service<Like>,ILikeService
    {
        public readonly IUnitOfWork _unit;
        private readonly IRepository<Like> _repo;

        public LikeService(IUnitOfWork unit, IRepository<Like> repo) : base(unit, repo)
        {
            _unit = unit;
            _repo = repo;
        }

        public async Task<Like> PostUserByID(Guid id, Guid lId, Like entity)
        {

            _repo.AddAsync(entity);
            _unit.CommitAsync();
            return await _unit.Like.PostUserByID(id, lId, entity);

        }
    }
}
