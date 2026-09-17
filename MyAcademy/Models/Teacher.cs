using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace MyAcademy.Models
{
    public class Teacher
    {
        [Key]
        public Int16 teacher_id     { get; set; } 
        [MaxLength(50)]             
        public string? last_name      { get; set; }
        [MaxLength(50)]             
        public string? first_name     { get; set; }
        [MaxLength(50)]             
        public string? middle_name    { get; set; }
        public DateTime? birth_date   { get; set; }
        [MaxLength(50)]          
        public string? email         { get; set; }
        [MaxLength(16)]             
        public string? phone         { get; set; }
        public byte[]? photo         { get; set; }
        public DateTime? work_since   { get; set; }
        public decimal? rate { get; set; }
    }                               
}
