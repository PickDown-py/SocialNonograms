using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SN.DAL.Abstract
{
    public interface IRepository<TEntity, TKey>
    {
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public Task<TEntity> Get(TKey key);
        public Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        public Task<TEntity> GetInclude(TKey key, params Expression<Func<TEntity, object>>[] includes);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<IEnumerable<TEntity>> GetN(int n);
        public Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        public Task<IEnumerable<TEntity>> GetAllInclude(params Expression<Func<TEntity, object>>[] includes);
        public Task Delete(TKey key);
        public Task<bool> Exists(TKey key);
        public Task<int> Count();
        public Task<int> Count(Expression<Func<TEntity, bool>> predicate);
    }
}