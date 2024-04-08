using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;  

namespace Assignement3.Models;




public class Course
{
    [Key] 
    public string CourseCode { get; set; } = null!;
    public string CourseName { get; set; } = null!;
    public string Semester { get; set; } = null!;
    public string Teacher { get; set; } = null!;
    
    




}