using System.Collections.Generic;
using SN.Model.Abstract;

namespace SN.Model
{
    public class GameModel: Abstract.Model
    {
        public string Name { get; set; }
        
        public int Rows { get; set; }   
        public int Columns { get; set; }
        
        public int[,] RowNumbers { get; set; }
        public int[,] ColumnNumbers { get; set; }

        public int RatingScore { get; set; }
        
        public UserModel Author { get; set; }
        
        public BoardModel Answer { get; set; }

        public BoardModel BoardModel { get; set; }
    }
}