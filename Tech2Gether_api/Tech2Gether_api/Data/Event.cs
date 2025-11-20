using System;

namespace Tech2Gether_api.Data;

public class Event
{
    public int EventId { get; set; }
    public int? EventSourceId { get; set; }
    public DateTime? EventDate { get; set; }
    public DateTime? EventEndDate { get; set; }

    public EventSource EventSource { get; set; }
    public ICollection<EventTeam> EventTeams { get; set; }
}