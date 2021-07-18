using System.Net.Http;
using SN.ClientServices.HttpClients.Abstract;
using SN.Entity;

namespace SN.ClientServices.HttpClients
{
    public class RatingHttpClient : GenericHttpClient<RatingEntity, int>
    {
        public RatingHttpClient(HttpClient http) : base(http)
        {
            Url = "api/Rating";
        }
    }
}