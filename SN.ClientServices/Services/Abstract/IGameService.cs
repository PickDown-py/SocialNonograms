using System.Collections.Generic;
using System.Threading.Tasks;
using SN.Model;

namespace SN.ClientServices.Services.Abstract
{
    public interface IGameService
    {
        Task<IEnumerable<GameModel>> GetAsync();

        Task<GameModel> GetAsync(int id);

        Task AddAsync(GameModel model);
    }
}