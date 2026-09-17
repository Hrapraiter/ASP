using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
    public class RequiredDiscipline
    {
        [Key , Column(Order = 1)]
        public Int16 discipline { get; set; }          //FK & PK
        [Key , Column(Order = 2)]
        public Int16 required_discipline { get; set; } //PK
    }
}
