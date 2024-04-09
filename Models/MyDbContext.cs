using Microsoft.EntityFrameworkCore;

namespace Assignement3.Models;

public class MyDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Grade> Grade { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "data source=dat154demo.database.windows.net;Initial Catalog=dat154;User ID=dat154_rw;Password=Svart_Katt;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("Student", schema: "dbo");
        modelBuilder.Entity<Course>().ToTable("Course", schema: "dbo");
        modelBuilder.Entity<Grade>().ToTable("Grade", schema: "dbo");
        modelBuilder.Entity<Grade>().HasKey(e=> new { e.StudentId, e.CourseCode });
        
    }

    public async Task<List<Student>> SearchStudents(string partialStudentName)
    {
        return await Students.Where(s => s.FirstName.Contains(partialStudentName) ||
                                         s.LastName.Contains(partialStudentName)).ToListAsync();
    }

    public async Task<List<Course>> SearchCourses(string partialCourseName)
    {
        return await Courses.Where(c => c.CourseName.Contains(partialCourseName)).ToListAsync();
        
    }

    
    public async Task<List<StudentGrade>> StudentsInCourse(String coursecode)

    {
        return await Grade
            .Include(g => g.Student)
            .Where(g => g.CourseCode == coursecode)
            .Select(a => new StudentGrade { Student = a.Student, Grade = a })
            .ToListAsync();

    }
    public async Task<List<StudentGradeCourse>> GradesAbove(String grade)
    {
        return await Grade
            .Include(g => g.Student)
            .Include(g => g.Course)
            .Where(g => string.Compare(g.Score, grade) <= 0)
            .Select(a => new StudentGradeCourse { Student = a.Student, Course = a.Course, Grade = a })
            .ToListAsync();
    }
    
    
}