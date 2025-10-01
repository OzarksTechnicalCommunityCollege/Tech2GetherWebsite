using System;

namespace Tech2Gether_api.Data;

public class Login
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public bool IsAdmin { get; set; }
    public string EmailVerificationToken { get; set; }
    public DateTime? EmailVerificationExpires { get; set; }
    public bool EmailIsVerified { get; set; }
    public string PasswordResetToken { get; set; }
    public DateTime? PasswordResetExpires { get; set; }

    public User User { get; set; }
}
