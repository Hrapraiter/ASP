using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Models
{
    public class Group
    {
        [Key]
        public int group_id { get; set; }
        [MaxLength(10)]
        public string group_name { get; set; }
        public byte direction { get; set; }     //FK
        public DateOnly? start_date { get; set; }
        public TimeOnly? start_time { get; set; }
        public byte? learning_days { get; set; }
    }
}
