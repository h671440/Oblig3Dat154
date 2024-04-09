using System.ComponentModel.DataAnnotations;

namespace Assignement3.Models;

public partial class Student
{
    public Student()
    {
        Grades = new HashSet<Grade>();
    }
    
    public int Id { get; set; }
    public string Studentname { get; set; } = null!;
    public int Studentage { get; set; }
    public virtual ICollection<Grade> Grades { get; set; }
}