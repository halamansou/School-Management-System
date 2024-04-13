using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int? NumberOfAttendees { get; set; }

    public string? EventName { get; set; }
}
