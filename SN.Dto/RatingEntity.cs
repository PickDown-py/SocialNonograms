namespace SN.DTO
{
    public class RatingEntity: Dto.Abstract.Dto
    {
        public bool IsPositive { get; set; }

        public int GameId { get; set; }
        public GameEntity Game { get; set; }
        
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}