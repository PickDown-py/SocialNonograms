using System.Net.Http;
using SN.ClientServices.HttpClients.Abstract;
using SN.Entity;

namespace SN.ClientServices.HttpClients
{
    public class RankHttpClient : GenericHttpClient<RankEntity, int>
    {
        public RankHttpClient(HttpClient http) : base(http)
        {
            Url = "api/Rank";
        }
    }
}