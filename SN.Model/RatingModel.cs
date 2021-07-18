namespace SN.Model
{
    public class RatingModel: Abstract.Model
    {
        public bool IsPositive { get; set; }
        
        public GameModel Game { get; set; }
        
        public UserModel User { get; set; }
    }
}