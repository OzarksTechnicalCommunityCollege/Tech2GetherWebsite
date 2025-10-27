using System;
using System.ComponentModel.DataAnnotations;

namespace Tech2Gether_api.Data;

public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int? MemId { get; set; }
    public string? EmFirstName { get; set; }
    public string? EmLastName { get; set; }
    public string? EmRelationship { get; set; }
    public string? EmPhone { get; set; }
    public string? UserGithub { get; set; }
    public string? UserLinkedin { get; set; }
    public string? Pronouns { get; set; }
    public string? PreName { get; set; }

    public MembershipDef MembershipDef { get; set; }
    public Login Login { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<UserOrg> UserOrgs { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<UserTeam> UserTeams { get; set; }
}
