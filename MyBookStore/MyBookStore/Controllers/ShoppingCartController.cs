using Microsoft.Ajax.Utilities;
using MyBookStore.Infrastructure;
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
        [Route("view-order")]
        [AreaAuthorize("Customer")]
        public ActionResult ViewOrder()
        {
            ViewBag.Title = "Đơn hàng của bạn";
            string email = HttpContext.User.Identity.Name;
            var customer = unitOfWork.CustomerRepository.Get(c => c.Email == email).Select(c => new CustomerViewModel{
                 Id=c.Id,
                 Name=c.Name,
                 Address=c.Address,
                 BirthDate=c.BirthDate,
                 Email= c.Email,
                 PhoneNumber=c.PhoneNumber
            }).FirstOrDefault();
            if (customer != null)
            {
                ViewBag.Customer = customer;
            }
            return View(GetShoppingCart());
        }
        [Route("place-order/{deliveryAddress}")]
        public string PlaceOrder(string deliveryAddress)
        {
            if (ModelState.IsValid)
            {
                string email = HttpContext.User.Identity.Name;
                //create new delivery information
                DeliveryInformation deliveryInformation = new DeliveryInformation();
                CustomerViewModel customer = unitOfWork.CustomerRepository.Get(c => c.Email == email)
                    .Select(c=>new CustomerViewModel {
                        Id = c.Id,
                        Name = c.Name,
                        Address = c.Address,
                        BirthDate = c.BirthDate,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber
                    }).FirstOrDefault();
                deliveryInformation.Id = Guid.NewGuid();
                deliveryInformation.PhoneNumber = customer.PhoneNumber;
                deliveryInformation.ReceiverName = customer.Name;
                deliveryInformation.DeliveryFee = 0;
                deliveryInformation.DeliveryAddress = deliveryAddress;

                //create new order object
                Order order = new Order();
                order.Id = Guid.NewGuid();
                order.TotalPriceOrder = GetShoppingCart().CalculateTotalPrice();
                order.OrderStatusId = 1;//admin not confirm yet
                order.CreatedDate = DateTime.UtcNow;
                order.DeliveryDate = DateTime.UtcNow.AddDays(3);
                order.DeliveryId = deliveryInformation.Id;
                order.CustomerId = customer.Id;

                //create new list of order detail objects
                List<OrderDetail> listOrderDetails = new List<OrderDetail>();
                foreach (CartItemViewModel cartItem in GetShoppingCart().CartItems)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.Id = Guid.NewGuid();
                    orderDetail.BookId = cartItem.BookItem.Id;
                    orderDetail.OrderQuantity = cartItem.Quantity;
                    orderDetail.TotalPrice = cartItem.BookItem.Price * cartItem.Quantity;
                    orderDetail.OrderId = order.Id;
                    listOrderDetails.Add(orderDetail);
                }
                using (var transaction = unitOfWork.Context.Database.BeginTransaction())
                {
                    try
                    {
                        //save delivery information
                        unitOfWork.Context.DeliveryInformation.Add(deliveryInformation);
                        //save order
                        unitOfWork.Context.Order.Add(order);
                        foreach (var orderDetail in listOrderDetails)
                        {
                            //save order detail
                            unitOfWork.Context.OrderDetail.Add(orderDetail);
                            //update quantity book
                            var book = unitOfWork.BookRepository.GetById(orderDetail.BookId);
                            book.Quantity -= orderDetail.OrderQuantity;
                            unitOfWork.BookRepository.Update(book);
                        }

                        unitOfWork.Save();
                        transaction.Commit();
                        //clear shopping cart
                        Session["ShoppingCart"] = null;
                        return Url.Action("Index","Book");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        unitOfWork.Dispose();
                        ViewBag.Error = "Error occur while saving data";
                        return "";
                    }
                }
                
            }
            return "";
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