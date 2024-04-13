using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Teacher
{
    public int? EmployeeId { get; set; }

    public int? ClassCode { get; set; }

    public int? CourseId { get; set; }

    public string? TeacherEmail { get; set; }

    public int? TeacherPhone { get; set; }

    public string? TeacherName { get; set; }

    public virtual Employee? Employee { get; set; }
}
