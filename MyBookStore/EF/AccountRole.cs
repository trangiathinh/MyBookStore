﻿using System;
using System.Collections.Generic;

namespace EF
{
    public partial class AccountRole
    {
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}
