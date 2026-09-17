using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
    
    public class TeacherDisciplineRelation
    {
        [Key , Column(Order = 1)]
        public Int16 teacher { get; set; }   //FK & PK   
        [Key , Column(Order = 2)]
        public Int16 discipline { get; set; }//FK & PK
        //[ForeignKey(nameof(teacher))]
        //public Teacher TeacherNavigation { get; set; } = null!;
        //[ForeignKey(nameof(discipline))]
        //public Discipline DisciplineNavigation { get; set; } = null!;
       
    }
}
