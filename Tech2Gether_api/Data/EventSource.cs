using System;

namespace Tech2Gether_api.Data;

public class EventSource
{
    public int EventSourceId { get; set; }
    public int EventTypeId { get; set; }
    public string EventName { get; set; }

    public EventDef EventDef { get; set; }
    public ICollection<Event> Events { get; set; }
}
