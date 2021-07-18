namespace SN.Entity
{
    public class RankEntity: Entity
    {
        [Newtonsoft.Json.JsonProperty("name")]
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("required_experience")]
        [System.Text.Json.Serialization.JsonPropertyName("required_experience")]
        public int RequiredExperience { get; set; }
    }
}