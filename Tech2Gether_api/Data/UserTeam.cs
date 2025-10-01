using System;

namespace Tech2Gether_api.Data;

public class UserTeam
{
    public int UserTeamId { get; set; }
    public int? TeamId { get; set; }
    public int? UserId { get; set; }
    public bool Leader { get; set; }

    public EventTeam EventTeam { get; set; }
    public User User { get; set; }
}
