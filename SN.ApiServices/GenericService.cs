using System.Collections.Generic;
using System.Threading.Tasks;
using SN.ApiServices.Abstract;
using SN.DAL.Abstract;

namespace SN.ApiServices
{
    public class GenericService<TEntity, TKey> : IService<TEntity, TKey> where TEntity : class
    {
        protected readonly IRepository<TEntity, TKey> Repository;

        public GenericService(IRepository<TEntity, TKey> repository)
        {
            Repository = repository;
        }
        
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities =  await Repository.GetAll();
            return entities;
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await Repository.Get(id);
        }

        public virtual void Add(TEntity entity)
        {
            Repository.Add(entity);
        }

        public virtual void Replace(TEntity entity)
        {
            Repository.Update(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Repository.Update(entity);
        }

        public virtual void Remove(TKey entity)
        {
            Repository.Delete(entity);
        }

        public virtual async Task<bool> ExistsAsync(TKey id)
        {
            return await Repository.Exists(id);
        }
    }
}
