using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SN.Model
{
    public class AuthenticatedUserModel
    {
        [JsonProperty(PropertyName="access_Token")]
        public string AccessToken { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"AccessToken: {AccessToken}, UserName: {UserName}";
        }
    }
}