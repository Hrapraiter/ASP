using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Schedule
    {
        [Key]
        public long lesson_id { get; set; }
        [ForeignKey(nameof(Group))]
        public int group { get; set; }
        
        [ForeignKey(nameof(Discipline))]
        [Column(TypeName = "SMALLINT")]
        public int discipline { get; set; }
         
        [ForeignKey(nameof(Teacher))]
        [Column(TypeName = "SMALLINT")]
        public int teacher { get; set; }
        public DateOnly? date { get; set; }
        public TimeOnly? time { get; set; }
        public bool? spent { get; set; }
        
        // Navigation
        public Group Group { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
        public Discipline Discipline { get; set; } = null!;
    }
}
