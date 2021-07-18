namespace SN.Model
{
    public class UserModel: Abstract.Model
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Likes { get; set; }

        public RankModel Rank { get; set; }
    }
}