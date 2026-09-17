using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Models
{
    public class Discipline
    {
        [Key]
        public Int16 discipline_id { get; set; }
        [MaxLength(150)]
        public string discipline_name { get; set; }
        public byte number_of_lessons { get; set; }
    }
}
