using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Teacher : Human
    {
        [Key]
        [Column(TypeName ="SMALLINT")]
        public int teacher_id { get; set; }
        [DisplayName("Начало работы")]
        public DateOnly? work_since { get; set; }
        [DisplayName("Зар.плата")]
        [Column(TypeName ="SMALLMONEY")]
        public int? rate { get; set; }

        //Navigation properties:
        [DisplayName("Назначенные дисциплины")]
        public ICollection<TeachersDisciplinesRelation>? TDRs { get; set; }
    }
}
