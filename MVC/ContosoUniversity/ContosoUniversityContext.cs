using Microsoft.EntityFrameworkCore;

public class ContosoUniversityContext(DbContextOptions<ContosoUniversityContext> options) : DbContext(options)
{
    public DbSet<ContosoUniversity.Models.Student> Students { get; set; } = default!;
    public DbSet<ContosoUniversity.Models.Course> Courses { get; set; } = default!;
    public DbSet<ContosoUniversity.Models.Enrollment> Enrollments { get; set; } = default!;
    public DbSet<ContosoUniversity.Models.Instructor> Instructors { get; set; } = default!;
    public DbSet<ContosoUniversity.Models.OfficeAssignment> OfficeAssigments { get; set; } = default!;
    public DbSet<ContosoUniversity.Models.Department> Departments { get; set; } = default!;
    public DbSet<ContosoUniversity.Models.CourseAssigment> CourseAssignments { get; set; } = default!;

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<ContosoUniversity.Models.Student>().ToTable("Student");
    //    modelBuilder.Entity<ContosoUniversity.Models.Course>().ToTable("Course");
    //    modelBuilder.Entity<ContosoUniversity.Models.Enrollment>().ToTable("Enrollment");
    //}
}
