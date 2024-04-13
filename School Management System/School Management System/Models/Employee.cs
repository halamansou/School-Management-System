using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int? EmployeeSalary { get; set; }

    public string? EmployeePosition { get; set; }

    public DateOnly? EmployeeHiringDate { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
