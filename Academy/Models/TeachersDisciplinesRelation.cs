using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Academy.Models
{
    [PrimaryKey(nameof(teacher),nameof(discipline))]
    public class TeachersDisciplinesRelation
    {
        [Column(TypeName = "SMALLINT")]
        [ForeignKey(nameof(Teacher))]
        public int teacher { get; set; }
        [Column (TypeName = "SMALLINT")]
        [ForeignKey(nameof(Discipline))]
        public int discipline { get; set; }

        // Navigation propertioes:
        public Teacher Teacher { get; set; }
        public Discipline Discipline { get; set; }
    }
}
