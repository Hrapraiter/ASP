using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    [PrimaryKey(nameof(InstructorId) , nameof(CourseId))]
    public class CourseAssignment
    {
        // Composite primary key
        [ForeignKey(nameof(Instructor))]
        public int InstructorId {  get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        // Composite primary key

        //Navigation properties:
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
