using System;
using System.Collections.Generic;

namespace MyBookStore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        public Guid DeliveryId { get; set; }
        public double TotalPriceOrder { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual DeliveryInformation Delivery { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
