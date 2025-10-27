using System;

namespace Tech2Gether_api.Data;

public class Attendance
{
    public int AttendanceId { get; set; }
    public int? UserId { get; set; }
    public int? MeetingId { get; set; }

    public User User { get; set; }
    public Meeting Meeting { get; set; }
}
