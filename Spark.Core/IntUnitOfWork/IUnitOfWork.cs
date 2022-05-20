﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.IntRepository;

namespace Spark.Core.IntUnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ILikeRepository Like { get; }
        IGameRepository Game { get; }
        Task CommitAsync();
        void Commit();
    }
}
