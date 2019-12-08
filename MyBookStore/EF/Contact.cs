using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Contact
    {
        public string NameStore { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
