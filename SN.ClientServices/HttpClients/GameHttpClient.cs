using System.Net.Http;
using SN.ClientServices.HttpClients.Abstract;
using SN.Entity;

namespace SN.ClientServices.HttpClients
{
    public class GameHttpClient : GenericHttpClient<GameEntity, int>
    {
        public GameHttpClient(HttpClient http) : base(http)
        {
            Url = "api/Game";
        }
    }
}