namespace SN.Entity
{
    public class GridStateEntity: Entity
    {
        [Newtonsoft.Json.JsonProperty("state")]
        [System.Text.Json.Serialization.JsonPropertyName("state")]
        public string State { get; set; }
    }
}