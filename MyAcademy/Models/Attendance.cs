using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
    public class Attendance
    {
        [Key , Column(Order = 1)]
        public int student { get; set; }    //FK & PK
        [Key , Column(Order = 2)]
        public Int64 lesson { get; set; }     //FK & PK
        public bool present { get; set; }

    }
}
