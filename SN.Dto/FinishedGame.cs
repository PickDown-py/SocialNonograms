namespace SN.DTO
{
    public class FinishedGame: Dto.Abstract.Dto
    {
        public GameEntity Game { get; set; }
        
        public UserEntity User { get; set; }
    }
}