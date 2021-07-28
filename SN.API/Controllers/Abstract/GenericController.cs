using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SN.ApiServices.Abstract;
using SN.Entity;

namespace SN.API.Controllers.Abstract
{
    public abstract class GenericController<TEntity, TKey> : ControllerBase where TEntity : class, IEntity<TKey>
    {
        protected readonly IService<TEntity, TKey> Service;
        
        protected GenericController(IService<TEntity, TKey> service)
        {
            Service = service;
        }
        
        [HttpGet]
        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await Service.GetAllAsync();
        }
        
        [HttpGet("{key}")]
        public virtual async Task<ActionResult<TEntity>> Get(TKey key)
        {
            var entity = await Service.GetAsync(key);
            if (entity == null)
                return NotFound();
            return new ObjectResult(entity);
        }

        [HttpPost]
        public virtual ActionResult<TEntity> Post(TEntity entity)
        {
            if (entity == null)
                return BadRequest();
            Service.Add(entity);
            return Ok(entity);
        }

        [HttpPut]
        public virtual async Task<ActionResult<TEntity>> Put(TEntity entity)
        {
            if (entity == null)
                return BadRequest();
            if (await Service.ExistsAsync(entity.Id))
                return NotFound();
            Service.Replace(entity);
            return Ok(entity);
        }

        [HttpPatch("{key}")]
        public virtual async Task<ActionResult<TEntity>> Patch(TKey key, 
            [FromBody] JsonPatchDocument<TEntity> patchDocument)
        {
            var entity = await Service.GetAsync(key);
            if (entity== null)
                return NotFound();
            patchDocument.ApplyTo(entity);
            Service.Update(entity);
            return Ok(entity);
        }

        [HttpDelete("{key}")]
        public virtual async Task<ActionResult<TEntity>> Delete(TKey key)
        {
            if (await Service.ExistsAsync(key))
                return NotFound();
            Service.Remove(key);
            return Ok(key);
        }
    }
}