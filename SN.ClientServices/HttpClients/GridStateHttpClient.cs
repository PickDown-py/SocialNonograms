using System.Net.Http;
using SN.ClientServices.HttpClients.Abstract;
using SN.Entity;

namespace SN.ClientServices.HttpClients
{
    public class GridStateHttpClient : GenericHttpClient<GridStateEntity, int>
    {
        public GridStateHttpClient(HttpClient http) : base(http)
        {
            Url = "api/GridState";
        }
    }
}