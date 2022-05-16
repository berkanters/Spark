using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spark.Core.IntRepository;

namespace Spark.DataAccessLayer.Repository
{
    public class Repository<T>:IRepository<T> where T:class
    {
        protected readonly SparkDBContext _db;
        public readonly DbSet<T> _dbSet;

        public Repository(SparkDBContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public T Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _dbSet.FirstOrDefaultAsync(predicate))!;
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _dbSet.SingleOrDefaultAsync(predicate))!;
        }

        public async Task<IQueryable<T>> QListAsync()
        {
            return await Task.FromResult(_dbSet.AsQueryable());
        }
    }
}
