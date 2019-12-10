using System;
using System.Collections.Generic;

namespace MyBookStore.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthor = new HashSet<BookAuthor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
    }
}
