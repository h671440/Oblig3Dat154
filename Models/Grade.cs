using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignement3.Models;


[Table("grade", Schema = "dbo")]
public class Grade
{
    [ForeignKey("Student"), Column("studentid", TypeName = "int")]
    public int StudentId { get; set; }
    public Student Student { get; set; }

    [ForeignKey("Course"), Column("coursecode", TypeName = "char(6)")]
    public string CourseCode { get; set; }
    public Course Course { get; set; }

    [Column("grade", TypeName = "char(1)")]
    public string Score { get; set; }
}