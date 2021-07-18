using System.Net.Http;
using SN.ClientServices.HttpClients.Abstract;
using SN.Entity;

namespace SN.ClientServices.HttpClients
{
    public class UnfinishedGameHttpClient : GenericHttpClient<UnfinishedGameEntity, int>
    {
        public UnfinishedGameHttpClient(HttpClient http) : base(http)
        {
            Url = "api/UnfinishedGame";
        }
    }
}