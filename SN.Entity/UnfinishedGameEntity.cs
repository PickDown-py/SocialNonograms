namespace SN.Entity
{
    public class UnfinishedGameEntity: Entity
    {
        public int GameId { get; set; }
        public GameEntity Game { get; set; }
        
        public int GridId { get; set; }
        public GridStateEntity Grid { get; set; }
        
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}