﻿namespace SN.Entity
{
    public class UnfinishedGameEntity: Entity
    {
        [Newtonsoft.Json.JsonProperty("game_id")]
        [System.Text.Json.Serialization.JsonPropertyName("game_id")]
        public int GameId { get; set; }
        [Newtonsoft.Json.JsonProperty("game")]
        [System.Text.Json.Serialization.JsonPropertyName("game")]
        public GameEntity Game { get; set; }
        
        [Newtonsoft.Json.JsonProperty("grid_id")]
        [System.Text.Json.Serialization.JsonPropertyName("grid_id")]
        public int GridId { get; set; }
        [Newtonsoft.Json.JsonProperty("grid")]
        [System.Text.Json.Serialization.JsonPropertyName("grid")]
        public GridStateEntity Grid { get; set; }
        
        [Newtonsoft.Json.JsonProperty("user_id")]
        [System.Text.Json.Serialization.JsonPropertyName("user_id")]
        public int UserId { get; set; }
        [Newtonsoft.Json.JsonProperty("user")]
        [System.Text.Json.Serialization.JsonPropertyName("user")]
        public UserEntity User { get; set; }
    }
}