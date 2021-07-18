using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SN.DAL.Abstract;
using SN.Entity;

namespace SN.DAL
{
    public class GenericRepository<TEntity, TKey>: IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> 
    {
        private readonly DbSet<TEntity> _set;
        private readonly SocialNonogramsContext _db;
        
        public GenericRepository(SocialNonogramsContext db)
        {
            _db = db;
            _set = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
            _db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
            _db.SaveChanges();
        }
        
        public async Task<TEntity> Get(TKey key)
        {
            return await _set.FindAsync(key);
        }
        
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _set.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetInclude(TKey key, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(_set.AsQueryable(), 
                    (current, include) => current.Include(include))
                .FirstOrDefaultAsync(e => e.Id.Equals(key));
        }

        public async Task<bool> Exists(TKey key)
        {
            return await Get(key) != null;
        }

        public async Task<int> Count()
        {
            return await _set.CountAsync();
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            return await _set.Where(predicate).CountAsync();
        }

        public async Task<IEnumerable<TEntity>> GetN(int n)
        {
            return await _set.Take(n).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _set.ToListAsync();
        }
        
        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _set.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(_set.AsQueryable(), 
                (current, include) => current.Include(include))
                .ToListAsync();
        }

        public async Task Delete(TKey key)
        {
            _set.Remove(await Get(key));
            await _db.SaveChangesAsync();
        }
    }
}