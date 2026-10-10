namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public DateTime EnrollmentDate { get; set; }
=======
        DateTime EnrollMent { get; set; }
>>>>>>> 81decac088b5e1a86e7c9dc8cfff7c6e805b91ed
=======
        DateTime EnrollMent { get; set; }
>>>>>>> 81decac088b5e1a86e7c9dc8cfff7c6e805b91ed
        
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
