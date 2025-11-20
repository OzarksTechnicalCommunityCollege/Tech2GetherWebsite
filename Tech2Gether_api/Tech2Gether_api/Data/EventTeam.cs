using System;

namespace Tech2Gether_api.Data;

public class EventTeam
{
    public int TeamId { get; set; }
    public int? EventId { get; set; }
    public int? UserTeamId { get; set; }
    public string TeamName { get; set; }

    public Event Event { get; set; }
    public UserTeam UserTeam { get; set; }
    public ICollection<UserTeam> UserTeams { get; set; }
}
