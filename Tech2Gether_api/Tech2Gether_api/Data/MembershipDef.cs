using System;

namespace Tech2Gether_api.Data;

public class MembershipDef
    {
        public int MemId { get; set; }
        public string MemDesc { get; set; }
        public bool Active { get; set; }

        public ICollection<User> Users { get; set; }
    }