using System.Net.Http;
using SN.ClientServices.HttpClients.Abstract;
using SN.Entity;

namespace SN.ClientServices.HttpClients
{
    public class UserHttpClient : GenericHttpClient<UserEntity, int>
    {
        public UserHttpClient(HttpClient http) : base(http)
        {
            Url = "api/User";
        }
    }
}