using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class ClassAttendance
{
    public int AttendanceId { get; set; }

    public int? ClassCode { get; set; }

    public int? EmployeeId { get; set; }

    public int? AttendeeStudentId { get; set; }

    public DateOnly? AttendanceDate { get; set; }

    public virtual Student? AttendeeStudent { get; set; }
}
