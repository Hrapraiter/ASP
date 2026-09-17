using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Models
{
    public class Direction
    {
        [Key]
        public byte direction_id { get; set; }
        [MaxLength(50)]
        public string direction_name { get; set; }
    }
}
