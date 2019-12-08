using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Rating
    {
        public Rating()
        {
            Reply = new HashSet<Reply>();
        }

        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid AccountId { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StatusComment { get; set; }

        public virtual Account Account { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
    }
}
