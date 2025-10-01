using System;

namespace Tech2Gether_api.Data;

public class UserOrg
{
    public int UserOrgId { get; set; }
    public int? OrgId { get; set; }
    public int? UserId { get; set; }
    public bool Active { get; set; }
    public DateTime? GraduationDate { get; set; }

    public Organization Organization { get; set; }
    public User User { get; set; }
}
