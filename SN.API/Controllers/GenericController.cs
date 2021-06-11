using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers
{
    
    public abstract class GenericController<TEntity, TKey> : ControllerBase where TEntity : class, IEntity<TKey>
    {
        private readonly IService<TEntity, TKey> _service;
        
        protected GenericController(IService<TEntity, TKey> service)
        {
            _service = service;
        }
        
        [HttpGet]
        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await _service.GetAll();
        }
        
        [HttpGet("{key}")]
        public virtual async Task<ActionResult<TEntity>> Get(TKey key)
        {
            var entity = await _service.Get(key);
            if (entity == null)
                return NotFound();
            return new ObjectResult(entity);
        }

        [HttpPost]
        public virtual ActionResult<TEntity> Post(TEntity entity)
        {
            if (entity == null)
                return BadRequest();
            _service.Add(entity);
            return Ok(entity);
        }

        [HttpPut]
        public virtual async Task<ActionResult<TEntity>> Put(TEntity entity)
        {
            if (entity == null)
                return BadRequest();
            if (await _service.Exists(entity.Id))
                return NotFound();
            _service.Replace(entity);
            return Ok(entity);
        }

        [HttpPatch("{key}")]
        public virtual async Task<ActionResult<TEntity>> Patch(TKey key, 
            [FromBody] JsonPatchDocument<TEntity> patchDocument)
        {
            var entity = await _service.Get(key);
            if (entity== null)
                return NotFound();
            patchDocument.ApplyTo(entity);
            _service.Update(entity);
            return Ok(entity);
        }

        [HttpDelete("{key}")]
        public virtual async Task<ActionResult<TEntity>> Delete(TKey key)
        {
            if (await _service.Exists(key))
                return NotFound();
            _service.Remove(key);
            return Ok(key);
        }
    }
}