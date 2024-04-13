using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentEmail { get; set; }

    public string? StudentGrade { get; set; }

    public string? StudentLevel { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<ClassAttendance> ClassAttendances { get; set; } = new List<ClassAttendance>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
