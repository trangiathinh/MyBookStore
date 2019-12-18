using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class CartItemViewModel
    {
        public BookViewModel BookItem { get; set; }
        public int Quantity { get; set; }
    }
    
}