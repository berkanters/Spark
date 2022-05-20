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
        IAnswerRepository Answer { get; }
        IUserRepository User { get; }
        ILikeRepository Like { get; }
        IChatRepository Chat { get; }
        Task CommitAsync();
        void Commit();
    }
}
