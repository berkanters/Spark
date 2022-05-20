using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.IntRepository;
using Spark.Core.IntUnitOfWork;
using Spark.DataAccessLayer.Repository;

namespace Spark.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SparkDBContext _db;
        private UserRepository _userRepository;
        private LikeRepository _likeRepository;


        public UnitOfWork(SparkDBContext db)
        {
            _db = db;
        }
        public IUserRepository User => _userRepository ?? new UserRepository(_db);
        public ILikeRepository Like => _likeRepository ?? new LikeRepository(_db);
        public IGameRepository Game { get; }

        public Task CommitAsync()
        {
            return _db.SaveChangesAsync();
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
