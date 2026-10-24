using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Discipline
    {
        [Key]
        [Column(TypeName ="SMALLINT")]
        public int discipline_id {  get; set; }
        [Required]
        [DisplayName("Дисциплина")]
        [StringLength(150 , MinimumLength = 2)]
        public string discipline_name { get; set; }
        [Required]
        [DisplayName("Число занятий")]
        [Column(TypeName = "TINYINT")]
        public int number_of_lessons { get; set; }

        //Navigation properties:
        [DisplayName("Назначенные преподаватели")]
        public ICollection<TeachersDisciplinesRelation>? TDRs { get; set; } = default!;
    }
}
