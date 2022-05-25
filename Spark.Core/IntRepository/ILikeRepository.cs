using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.Models;

namespace Spark.Core.IntRepository
{
    public interface ILikeRepository : IRepository<Like>
    {
        void MatchUsersWithUserIDs(Guid id, Guid lId);
        bool IsThereAnyMatch(Guid id,Guid lId);
        void RemoveMatch(Guid id, Guid lId);

        void ScoreUp(Guid id1, Guid id2, int score);

        bool IsThereAnyWin(Guid id1, Guid id2);

        Task<IEnumerable<Like>> GetAllMyMatches(Guid id);


    }
}
