using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SN.ApiServices.Abstract;
using SN.DAL.Abstract;
using SN.Entity;

namespace SN.ApiServices
{
    public class GameService : GenericService<GameEntity, int>, IGameService
    {
        public GameService(IRepository<GameEntity, int> repository) : base(repository)
        {
        }

        
        public override async Task<IEnumerable<GameEntity>> GetAllAsync()
        {
            return await Repository
                .GetAllInclude(g => g.Author, g => g.Answer);
        }

        public override async Task<GameEntity> GetAsync(int id)
        {
            return await Repository
                .GetInclude(id, g => g.Author, g => g.Answer);
        }
    }
}