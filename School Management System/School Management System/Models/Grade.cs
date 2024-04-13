using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? CourseId { get; set; }

    public int? StudentId { get; set; }

    public string? StudentGrade { get; set; }

    public string? TotalGrade { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
