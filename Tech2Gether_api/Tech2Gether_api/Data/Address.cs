using System;

namespace Tech2Gether_api.Data;

public class Address
{
    public int AddressId { get; set; }
    public int? UserId { get; set; }
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public User User { get; set; }
}
