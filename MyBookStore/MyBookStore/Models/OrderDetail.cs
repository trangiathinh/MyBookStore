using System;
using System.Collections.Generic;

namespace MyBookStore.Models
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public int OrderQuantity { get; set; }
        public double TotalPrice { get; set; }
        public Guid OrderId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
