using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Management
{
    public int? EmployeeId { get; set; }

    public int? EventId { get; set; }

    public string? ManagementEmployeeEmail { get; set; }

    public int? ManagementEmployeePhone { get; set; }

    public string? ManagementEmployeeName { get; set; }

    public virtual Employee? Employee { get; set; }
}
