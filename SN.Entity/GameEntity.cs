using System.ComponentModel.DataAnnotations.Schema;

namespace SN.Entity
{
    public class GameEntity: Entity
    {
        [Newtonsoft.Json.JsonProperty("name")]
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("rows")]
        [System.Text.Json.Serialization.JsonPropertyName("rows")]
        public int Rows { get; set; }   
        [Newtonsoft.Json.JsonProperty("columns")]
        [System.Text.Json.Serialization.JsonPropertyName("columns")]
        public int Columns { get; set; }
        
        [Newtonsoft.Json.JsonProperty("rating_score")]
        [System.Text.Json.Serialization.JsonPropertyName("rating_score")]
        [NotMapped] 
        public int RatingScore { get; set; }
        [Newtonsoft.Json.JsonProperty("author_id")]
        [System.Text.Json.Serialization.JsonPropertyName("author_id")]
        public int AuthorId { get; set; }
        [Newtonsoft.Json.JsonProperty("author")]
        [System.Text.Json.Serialization.JsonPropertyName("author")]
        public UserEntity Author { get; set; }
        [Newtonsoft.Json.JsonProperty("answer_id")]
        [System.Text.Json.Serialization.JsonPropertyName("answer_id")]
        public int AnswerId { get; set; }
        [Newtonsoft.Json.JsonProperty("answer")]
        [System.Text.Json.Serialization.JsonPropertyName("answer")]
        public GridStateEntity Answer { get; set; }
    }
}