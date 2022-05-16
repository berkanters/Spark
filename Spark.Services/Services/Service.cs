using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Spark.Core.IntRepository;
using Spark.Core.IntService;
using Spark.Core.IntUnitOfWork;

namespace Spark.Services.Services
{
    public class Service<T> : IService<T> where T:class
    {
        public readonly IUnitOfWork _unit;
        private readonly IRepository<T> _repo;

        public Service(IUnitOfWork unit, IRepository<T> repo)
        {
            _unit = unit;
            _repo = repo;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repo.AddAsync(entity);
            await _unit.CommitAsync();
            return entity;
        }

        public T Update(T entity)
        {
            _repo.Update(entity);
            _unit.Commit();
            return entity;
        }

        public void Remove(T entity)
        {
            _repo.Remove(entity);
            _unit.Commit();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repo.RemoveRange(entities);
            _unit.Commit();
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _repo.Where(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repo.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repo.SingleOrDefaultAsync(predicate);
        }

        public async Task<IQueryable<T>> QListAsync()
        {
            return await _repo.QListAsync();
        }
    }
}
