using System;

namespace Tech2Gether_api.Data;

public class SpeakerMeeting
{
    public int SpeakerMeetingId { get; set; }
    public int? SpeakerId { get; set; }
    public int? MeetingId { get; set; }

    public Speaker Speaker { get; set; }
    public Meeting Meeting { get; set; }
}
