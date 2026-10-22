using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    [PrimaryKey(nameof(InstructorID) , nameof(CourseID))]
    public class CourseAssignment
    {
        // Composite primary key
        [ForeignKey(nameof(Instructor))]
        public int InstructorID {  get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseID { get; set; }
        // Composite primary key

        //Navigation properties:
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
