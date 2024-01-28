using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class ApiEvent
{
    public int ApiEventId { get; set; }

    public int EventId { get; set; }

    public string? AdditionalInformation { get; set; }

    public virtual Event Event { get; set; } = null!;
}
