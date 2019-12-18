using MyBookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Models
{
    public class ShoppingCart
    {
        public List<CartItemViewModel> CartItems { get; }
        public ShoppingCart()
        {
            CartItems = new List<CartItemViewModel>();
        }
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
        public void RemoveItem(Guid bookId)
        {
            CartItems.RemoveAll(item => item.BookItem.Id == bookId);
        }
        public void ClearCartItems()
        {
            CartItems.Clear();
        }
        public void UpdateCartItem(Guid bookId,int quantity)
        {
            CartItemViewModel cartItem = CartItems.Where(c => c.BookItem.Id == bookId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
            }
        }
        public double CalculateTotalPrice()
        {
            return CartItems.Sum(item => item.BookItem.Price * item.Quantity);
        }
    }
}