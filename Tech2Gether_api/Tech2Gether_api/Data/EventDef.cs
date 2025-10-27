using System;

namespace Tech2Gether_api.Data;


public class EventDef
{
    public int EventTypeId { get; set; }
    public string EventTypeDesc { get; set; }
    public bool Active { get; set; }

    public ICollection<EventSource> EventSources { get; set; }
}