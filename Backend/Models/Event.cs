using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int UserId { get; set; }

    public string EventName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<ApiEvent> ApiEvents { get; } = new List<ApiEvent>();

    public virtual ICollection<Eventlog> Eventlogs { get; } = new List<Eventlog>();

    public virtual User User { get; set; } = null!;
}
