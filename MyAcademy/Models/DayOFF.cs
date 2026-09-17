using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
    public class DayOFF
    {
        [Key , Column(Order = 1)]
        public DateOnly date { get; set; } // PK
        [Key , Column(Order = 2)]
        public byte holiday { get; set; }  // FK & PK
    }
}
