using System;

namespace Tech2Gether_api.Data;

public class Meeting
{
    public int MeetingId { get; set; }
    public string Title { get; set; }
    public DateTime? MeetingDate { get; set; }

    public ICollection<SpeakerMeeting> SpeakerMeetings { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
}
