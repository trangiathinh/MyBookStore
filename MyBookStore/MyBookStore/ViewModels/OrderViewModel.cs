using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DeliveryId { get; set; }
        public double TotalPriceOrder { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}