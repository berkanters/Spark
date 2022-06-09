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

        public bool IsThereAnyMatch(Guid id, Guid lId)
        {
            return _unit.Like.IsThereAnyMatch(id, lId);
        }

        public void RemoveMatch(Guid id, Guid lId)
        {
            _unit.Like.RemoveMatch(id,lId);
            _unit.Commit();
        }

        public void ScoreUp(Guid id1, Guid id2, int score)
        {
            _unit.Like.ScoreUp(id1, id2, score);
            _unit.Commit();
        }

        public bool IsThereAnyWin(Guid id1, Guid id2)
        {
            //_unit.Like.IsThereAnyWin(id1, id2);
            //_unit.Commit();
            //return _unit.Like.IsThereAnyWin(id1, id2);

            if (_unit.Like.IsThereAnyWin(id1, id2))
            {
                _unit.Commit();
                return true;
            }
            else
            {
                _unit.Commit();
                return false;
            }
        }

        public async Task<IEnumerable<Like>> GetAllMyMatches(Guid id)
        {
            return await _unit.Like.GetAllMyMatches(id);
        }

        public Task<IQueryable<User>> GetMyMatchesWithUsers(Guid id)
        {
            return  _unit.Like.GetMyMatchesWithUsers(id);
        }
    }
}
