using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Account
    {
        public Account()
        {
            AccountRole = new HashSet<AccountRole>();
            Rating = new HashSet<Rating>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<AccountRole> AccountRole { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
