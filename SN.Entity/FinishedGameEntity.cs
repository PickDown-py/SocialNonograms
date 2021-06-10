namespace SN.Entity
{
    public class FinishedGameEntity: Entity
    {
        public int GameId { get; set; }
        public GameEntity Game { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}