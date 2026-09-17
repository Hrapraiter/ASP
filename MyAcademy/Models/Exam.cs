using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
    public class Exam
    {
        [Key , Column(Order = 1)]
        public int student { get; set; }       //FK & PK       
        [Key , Column(Order = 2)]
        public Int16 discipline { get; set; }  //FK & PK
        public DateTime? date { get; set; }
        public byte? grade { get; set; }

    }
}
