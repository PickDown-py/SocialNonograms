using System.ComponentModel.DataAnnotations;

namespace SN.Entity
{
    public class Entity: IEntity<int>
    {
        [Key]
        public int Id { get; set; }
    }
}