using System;
using System.Collections.Generic;

namespace MyBookStore.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Book = new HashSet<Book>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
