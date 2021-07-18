using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SN.ClientServices.HttpClients;
using SN.ClientServices.Services.Abstract;
using SN.Model;
using SN.ClientServices.Mappers;

namespace SN.ClientServices.Services
{
    public class GameService : IGameService
    {
        private GameHttpClient _http;

        public GameService(GameHttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<GameModel>> GetAsync()
        {
            return (await _http.GetAsync()).Select(g => g.ToModel());
        }

        public async Task<GameModel> GetAsync(int id)
        {
            return (await _http.GetAsync(id)).ToModel();
        }

        public async Task AddAsync(GameModel model)
        {
            await _http.PostAsync(model.ToEntity());
        }
    }
}