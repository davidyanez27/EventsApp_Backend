using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Eventlog
{
    public int LogId { get; set; }

    public int EventId { get; set; }

    public string ActivityType { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual Event Event { get; set; } = null!;
}
