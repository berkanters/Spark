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
        private readonly IRepository<Like> _repo;
        public readonly IUnitOfWork _unit;

        public LikeService(IUnitOfWork unit, IRepository<Like> repo) : base(unit, repo)
        {
            _repo = repo;
            _unit = unit;
        }


        public void MatchUsersWithUserIDs(Guid id, Guid lId)
        {
            //_repo.MatchUsersWithUserIDs(id, lId, entity);
            _unit.Like.MatchUsersWithUserIDs(id, lId);
            _unit.Commit();

        }
    }
}
