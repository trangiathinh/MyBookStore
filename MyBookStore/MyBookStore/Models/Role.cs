using System;
using System.Collections.Generic;

namespace MyBookStore.Models
{
    public partial class Role
    {
        public Role()
        {
            AccountRole = new HashSet<AccountRole>();
        }

        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<AccountRole> AccountRole { get; set; }
    }
}
