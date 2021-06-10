namespace SN.DTO
{
    public class GameEntity: Dto.Abstract.Dto
    {
        public string Name { get; set; }
        
        public int Rows { get; set; }   
        public int Columns { get; set; }

        public string RowNumbers { get; set; } // 1,2,3;4,5,6;
        public string ColumnNumbers { get; set; }

        public int AuthorId { get; set; }
        public UserEntity Author { get; set; }

        public int AnswerId { get; set; }
        public GridStateEntity Answer { get; set; }
    }
}