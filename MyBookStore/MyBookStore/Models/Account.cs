using System;
using System.Collections.Generic;

namespace MyBookStore.Models
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
        public string Email { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        public Guid ActiveCode { get; set; }
        public bool IsActive { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<AccountRole> AccountRole { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
