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
            return View();
        }
        [Route("add-to-card/{bookId}/{quantity}")]
        public ActionResult AddToCart(string bookId, int quantity = 1)
        {
            BookViewModel bookViewModel = unitOfWork.BookRepository.Get(book => book.Id == new Guid(bookId)).
                Select(book => new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    DiscountPrice = book.DiscountPrice,
                    ImagePath = book.ImagePath
                }).FirstOrDefault();
            if (bookViewModel != null)
            {
                GetShoppingCart().AddItem(bookViewModel, quantity);
                TempData["Message"] = "Sản phẩm đã được thêm vào giỏ hàng!";
            }
            return RedirectToAction("Detail", "Book", new { id = bookId });
        }
        private ShoppingCart GetShoppingCart()
        {
            if (Session["ShoppingCart"] == null)
            {
                return new ShoppingCart();
            }
            else
            {
                return Session["ShoppingCart"] as ShoppingCart;
            }
        }
    }
}