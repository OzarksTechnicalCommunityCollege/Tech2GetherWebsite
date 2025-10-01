using System;

namespace Tech2Gether_api.Data;

public class Organization
{
    public int OrgId { get; set; }
    public string OrgName { get; set; }
    public int? TypeId { get; set; }
    public string OrgPhone { get; set; }
    public int? AddressId { get; set; }
    public string OrgEmail { get; set; }

    public Address Address { get; set; }
    public ICollection<UserOrg> UserOrgs { get; set; }
}
