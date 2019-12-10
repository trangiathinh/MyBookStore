using System;
using System.Collections.Generic;

namespace MyBookStore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
