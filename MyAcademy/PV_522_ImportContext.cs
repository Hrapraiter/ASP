using Microsoft.EntityFrameworkCore;
using MyAcademy.Models;

public class PV_522_ImportContext(DbContextOptions<PV_522_ImportContext> options) : DbContext(options)
{
    public DbSet<MyAcademy.Models.Attendance> Attendance { get; set; } = default!;
    public DbSet<MyAcademy.Models.Teacher> Teachers { get; set; } = default!;
    public DbSet<MyAcademy.Models.CompleteDiscipline> CompleteDisciplines { get; set; } = default!;
    public DbSet<MyAcademy.Models.TeacherDisciplineRelation> TeachersDisciplinesRelation { get; set; } = default!;
    public DbSet<MyAcademy.Models.Group> Groups { get; set; } = default!;
    public DbSet<MyAcademy.Models.Grade> Grades { get; set; } = default!;
    public DbSet<MyAcademy.Models.DayOFF> DaysOFF { get; set; } = default!;
    public DbSet<MyAcademy.Models.Direction> Directions { get; set; } = default!;
    public DbSet<MyAcademy.Models.Discipline> Disciplines { get; set; } = default!;
    public DbSet<MyAcademy.Models.DependentDiscipline> DependentDisciplines { get; set; } = default!;
    public DbSet<MyAcademy.Models.DisciplineDirectionRelation> DisciplinesDirectionsRelation { get; set; } = default!;
    public DbSet<MyAcademy.Models.Student> Students { get; set; } = default!;
    public DbSet<MyAcademy.Models.Schedule> Schedule { get; set; } = default!;
    public DbSet<MyAcademy.Models.Exam> Exams { get; set; } = default!;
    public DbSet<MyAcademy.Models.Holiday> Holidays { get; set; } = default!; 
    public DbSet<MyAcademy.Models.RequiredDiscipline> RequiredDisciplines { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => new { e.student, e.lesson });
        });
        modelBuilder.Entity<TeacherDisciplineRelation>(entity =>
        {
            entity.HasKey(e => new { e.teacher, e.discipline });
        });
        modelBuilder.Entity<RequiredDiscipline>(entity => 
        {
            entity.HasKey(e => new { e.discipline, e.required_discipline });
        });
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => new { e.student, e.lesson });
        });
        modelBuilder.Entity<Exam>(entity => 
        {
            entity.HasKey(e => new { e.student, e.discipline });
        });
        modelBuilder.Entity<DisciplineDirectionRelation>(entity =>
        {
            entity.HasKey(e => new { e.direction, e.discipline });
        });
        modelBuilder.Entity<DependentDiscipline>(entity =>
        {
            entity.HasKey(e => new { e.discipline, e.dependent_discipline });
        });
        modelBuilder.Entity<DayOFF>(entity =>
        {
            entity.HasKey(e => new { e.date, e.holiday });
        });
        modelBuilder.Entity<CompleteDiscipline>(entity =>
        {
            entity.HasKey(e => new {e.group, e.discipline });
        });
    }
}
