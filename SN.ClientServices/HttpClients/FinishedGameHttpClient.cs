using System.Net.Http;
using SN.ClientServices.HttpClients.Abstract;
using SN.Entity;

namespace SN.ClientServices.HttpClients
{
    public class FinishedGameHttpClient : GenericHttpClient<FinishedGameEntity, int>
    {
        public FinishedGameHttpClient(HttpClient http) : base(http)
        {
            Url = "api/FinishedGame";
        }
    }
}