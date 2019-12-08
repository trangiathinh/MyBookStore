using System;
using System.Collections.Generic;

namespace EF
{
    public partial class DeliveryInformation
    {
        public DeliveryInformation()
        {
            Order = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string ReceiverName { get; set; }
        public string PhoneNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal? DeliveryFee { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
