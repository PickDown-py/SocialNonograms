namespace SN.DTO
{
    public class GridStateEntity: Dto.Abstract.Dto
    {
        public string State { get; set; }

        public int GameId { get; set; }
        public GameEntity Game { get; set; }
    }
}