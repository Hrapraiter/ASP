using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorId { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        //Navigation properties:
        public Instructor Instructor { get; set; }

    }
}
