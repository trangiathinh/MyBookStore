using System;
using System.Collections.Generic;

namespace EF
{
    public partial class BookType
    {
        public BookType()
        {
            Book = new HashSet<Book>();
        }

        public Guid Id { get; set; }
        public string BookTypeName { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
