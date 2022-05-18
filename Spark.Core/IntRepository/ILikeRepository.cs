﻿using System;
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
      

    }
}
