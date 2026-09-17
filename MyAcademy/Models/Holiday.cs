using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Models
{
    public class Holiday
    {
        [Key]
        public byte holiday_id { get; set; }
        [MaxLength(50)]
        public string holiday_name { get; set; }
        public byte? mounth { get; set; }
        public byte? day { get; set; }
        public byte duration { get; set; }
    }
}
