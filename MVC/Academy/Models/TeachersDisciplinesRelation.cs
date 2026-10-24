using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    [PrimaryKey(nameof(teacher) , nameof(discipline))]
    public class TeachersDisciplinesRelation
    {
        [ForeignKey(nameof(Teacher))]
        public int teacher {  get; set; }

        [ForeignKey(nameof(Discipline))]
        public int discipline { get; set; }

        //Navigation properties:
        public Teacher Teacher { get; set; }
        public Discipline Discipline { get; set; }
    }
}
