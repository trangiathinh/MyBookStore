using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class OrderDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public int OrderQuantity { get; set; }
        public double TotalPrice { get; set; }
        public double Price { get; set; }
        public Guid OrderId { get; set; }
        public string  Image { get; set; }
        public string Title { get; set; }
        
    }
}