using MyBookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Models
{
    public class ShoppingCart
    {
        private List<CartItemViewModel> CartItems { get; }
        public void AddItem(BookViewModel book, int quantity)
        {
            //check if list item already contains book
            CartItemViewModel item = CartItems.Where(i => i.BookItem.Id == book.Id).FirstOrDefault();
            if (item != null)
            {
                //update quantity
                item.Quantity += quantity;
            }
            else
            {
                //add new item
                CartItems.Add(new CartItemViewModel { BookItem = book, Quantity = quantity });
            }

        }
        public void RemoveItem(Guid idBook)
        {
            CartItems.RemoveAll(item => item.BookItem.Id == idBook);
        }
        public void ClearCartItems()
        {
            CartItems.Clear();
        }
    }
}