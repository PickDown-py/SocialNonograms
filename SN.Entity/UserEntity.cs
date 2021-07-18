namespace SN.Entity
{
    public class UserEntity: Entity
    {
        [Newtonsoft.Json.JsonProperty("name")]
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("experience")]
        [System.Text.Json.Serialization.JsonPropertyName("experience")]
        public int Experience { get; set; }
        [Newtonsoft.Json.JsonProperty("likes")]
        [System.Text.Json.Serialization.JsonPropertyName("likes")]
        public int Likes { get; set; }
        [Newtonsoft.Json.JsonProperty("login")]
        [System.Text.Json.Serialization.JsonPropertyName("login")]
        public string Login { get; set; }
        [Newtonsoft.Json.JsonProperty("password")]
        [System.Text.Json.Serialization.JsonPropertyName("password")]
        public string Password { get; set; }

        [Newtonsoft.Json.JsonProperty("rank_id")]
        [System.Text.Json.Serialization.JsonPropertyName("rank_id")]
        public int RankId { get; set; }
        [Newtonsoft.Json.JsonProperty("rank")]
        [System.Text.Json.Serialization.JsonPropertyName("rank")]
        public RankEntity Rank { get; set; }
    }
}