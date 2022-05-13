using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.IntRepository;
using Spark.Core.IntUnitOfWork;

namespace Spark.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SparkDBContext _db;

        public UnitOfWork(SparkDBContext db)
        {
            _db = db;
        }
        public IAnswerRepository Answer { get; }
        public IUserRepository User { get; }
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
