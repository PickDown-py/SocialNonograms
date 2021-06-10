using System.ComponentModel.DataAnnotations;

namespace SN.Dto.Abstract
{
    public class Dto: IDto<int>
    {
        [Key]
        public int Id { get; set; }
    }
}