using System.Collections.Generic;
using System.Threading.Tasks;
using SN.DAL.Abstract;

namespace SN.ApiServices.Abstract
{
    public class GenericService<TEntity, TKey> : IService<TEntity, TKey> where TEntity : class
    {
        protected readonly IRepository<TEntity, TKey> _repository;

        public GenericService(IRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var entities =  await _repository.GetAll();
            return entities;
        }

        public async Task<TEntity> Get(TKey id)
        {
            return await _repository.Get(id);
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Replace(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Remove(TKey entity)
        {
            _repository.Delete(entity);
        }

        public async Task<bool> Exists(TKey id)
        {
            return await _repository.Exists(id);
        }
    }
}
