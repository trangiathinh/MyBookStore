using MyBookStore.Models;
using MyBookStore.Repository;
using MyBookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    [RoutePrefix("customer/shopping-cart")]
    public class ShoppingCartController : Controller
    {
        private IUnitOfWork unitOfWork;
        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: customer/shopping-cart
        [Route()]
        public ActionResult Index()
        {
            ViewBag.Title = "Giỏ hàng";
            if (Session["ShoppingCart"] != null)
            {
                //var listItems = GetShoppingCart().CartItems;
                //return View(listItems);
                return View(Session["ShoppingCart"] as ShoppingCart);
            }
            ViewBag.Message = "Bạn chưa có sản phẩm nào trong giỏ hàng!";
            return View(new ShoppingCart());
        }
        [Route("add-to-card/{bookId}/{quantity}")]
        public string AddToCart(string bookId, int quantity = 1)
        {
            string message = "";
            BookViewModel bookViewModel = unitOfWork.BookRepository.Get(book => book.Id == new Guid(bookId)).
                Select(book => new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    DiscountPrice = book.DiscountPrice,
                    Quantity=book.Quantity,
                    ImagePath = book.ImagePath
                }).FirstOrDefault();
            if (bookViewModel != null)
            {
                GetShoppingCart().AddItem(bookViewModel, quantity);
                message = "Sản phẩm đã được thêm vào giỏ hàng!";
            }
            return message;
        }
        [Route("remove-from-cart/{bookId}")]
        public void RemoveCartItem(string bookId)
        {
            GetShoppingCart().RemoveItem(new Guid(bookId));
            
        }
        [Route("update-from-cart/{bookId}/{quantity}")]
        public void UpdateCartItem(string bookId, int quantity)
        {
            GetShoppingCart().UpdateCartItem(new Guid(bookId), quantity);
        }
        private ShoppingCart GetShoppingCart()
        {
            if (Session["ShoppingCart"] == null)
            {
                ShoppingCart shoppingCart= new ShoppingCart();
                Session["ShoppingCart"] = shoppingCart;
                return shoppingCart;
            }
            else
            {
                return Session["ShoppingCart"] as ShoppingCart;
            }
        }
    }
}