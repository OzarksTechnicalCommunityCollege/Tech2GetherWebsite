using System;

namespace Tech2Gether_api.Data;

public class Speaker
{
    public int SpeakerId { get; set; }
    public string SpeakerFirstName { get; set; }
    public string SpeakerLastName { get; set; }
    public string SpeakerLinkedin { get; set; }
    public int? SpeakerOrganization { get; set; }
    public string SpeakerTitle { get; set; }

    public Organization Organization { get; set; }
    public ICollection<SpeakerMeeting> SpeakerMeetings { get; set; }
}
