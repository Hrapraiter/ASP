using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
    public class Schedule
    {
        [Key]
        public Int64 lesson_id { get; set; }
        public int group { get; set; }          //FK
        public Int16 discipline { get; set; }   //FK
        public Int16 teacher { get; set; }      //FK
        public DateOnly? date { get; set; }
        public TimeOnly? time { get; set; }
        public bool? spent { get; set; }   
    }
}
