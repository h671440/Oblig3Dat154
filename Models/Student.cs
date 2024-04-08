using System.ComponentModel.DataAnnotations;

namespace Assignement3.Models;

public class Student
{
    public Student()
    {
        Grades = new HashSet<Grade>();

        
    }
    [Key]
    public int StudentId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    
    public virtual ICollection<Grade> Grades { get; set; }
    
    
    
    
}