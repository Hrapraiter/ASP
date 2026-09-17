using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
    public class Grade
    {
        [Key , Column(Order = 1)]
        public int student { get; set; }   //FK & PK
        [Key , Column(Order = 2)]
        public Int64 lesson { get; set; } //FK & PK
        public byte? grade_1 { get; set; }
        public byte? grade_2 { get; set; }

        
    }
}
