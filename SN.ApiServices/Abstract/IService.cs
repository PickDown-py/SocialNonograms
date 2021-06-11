using System.Collections.Generic;
using System.Threading.Tasks;

namespace SN.ApiServices.Abstract
{
    public interface IService<TEntity, TKey>
    {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> Get(TKey id);
        public void Add(TEntity entity);
        public void Replace(TEntity entity);
        public void Update(TEntity entity);
        public void Remove(TKey entity);
        public Task<bool> Exists(TKey id);
    }
}