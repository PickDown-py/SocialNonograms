namespace SN.Entity
{
    public class GridStateEntity: Entity
    {
        public string State { get; set; }

        public int GameId { get; set; }
        public GameEntity Game { get; set; }
    }
}