﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBookStore.Infrastructure;
using MyBookStore.Models;
using MyBookStore.Repository;
using MyBookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;


namespace MyBookStore.Controllers
{
    [RoutePrefix("account/customer")]
    public class AccountController : Controller

    {
        private IUnitOfWork unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: Account
        [HttpGet, Route("login")]
        public ViewResult Login()
        {
            ViewBag.Title = "Đăng nhập tài khoản";
            return View();
        }

        [HttpPost, Route("login")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //check account exist
                Account account = unitOfWork.AccountRepository.Login(model);
                if (account != null && account.IsActive)
                {
                    int timeout = model.RememberMe ? 20 : 10;
                    List<string> roleNames = unitOfWork.Context.AccountRole.Where(r => r.AccountId == account.Id).Include(r => r.Role).Select(r => r.Role.RoleName).ToList();
                    string roles = string.Join("|", roleNames);
                    var ticket = new FormsAuthenticationTicket(1, account.Customer.Email, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(timeout), model.RememberMe, roles);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.UtcNow.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác hoặc tài khoản chưa được kích hoạt!");
                    ViewBag.Title = "Đăng nhập tài khoản";
                    return View(model);
                }
            }
            else
            {
                ViewBag.Title = "Đăng nhập tài khoản";
                return View(model);
            }
        }
        [AreaAuthorize("Customer")]
        [Route("logout")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        [Route("register")]
        public ActionResult Register()
        {
            ViewBag.Title = "Đăng ký tài khoản";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("register")]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //check email already exists
                if (!unitOfWork.AccountRepository.IsUniqueEmail(model.Email))
                {
                    ModelState.AddModelError("EmailExist", "Email already exist!");
                    ViewBag.Title = "Đăng ký tài khoản";
                    return View(model);
                }
                //create customer
                Customer customer = new Customer();
                customer.Id = Guid.NewGuid();
                customer.Name = model.Name;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Email = model.Email;
                customer.CreatedDate = DateTime.UtcNow;
                customer.BirthDate = model.Birthday;
                customer.Address = model.Address;
                customer.Gender = "Nam";
                //create account
                Account account = new Account();
                account.Id = Guid.NewGuid();
                account.CustomerId = customer.Id;
                account.Salt = SaltHelper.GenerateSalt(10);
                account.PasswordHash = Crypto.SHA256(model.Password + account.Salt);
                account.Email = model.Email;
                account.IsActive = false;
                account.ActiveCode = Guid.NewGuid();

                ////get role
                Role customerRole = unitOfWork.RoleRepository.Get(r => r.RoleName == "Customer").First();

                //save database
                using (var transaction = unitOfWork.Context.Database.BeginTransaction())
                {
                    try
                    {
                        unitOfWork.CustomerRepository.Create(customer);
                        unitOfWork.AccountRepository.Create(account);
                        customerRole.AccountRole.Add(new AccountRole { AccountId = account.Id, RoleId = customerRole.Id });
                        unitOfWork.Save();
                        transaction.Commit();
                        TempData["Message"] = "Tài khoản đã được tạo thành công vui lòng kiểm tra email để kích hoạt tài khoản!";

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("Error", "Error occured!");
                        ViewBag.Title = "Đăng ký tài khoản";
                        transaction.Rollback();
                        return View(model);
                    }
                }
                //send email
                try
                {
                    SendEmail(account.Email, "Tạo tài khoản thành công!",
                        "/account/customer/verify-email/" + account.ActiveCode.ToString(),
                        "Xin vui lòng click vào link bên dưới để kích hoạt tài khoản.");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error while sending email!";
                    ViewBag.Title = "Đăng ký tài khoản";
                    return View("Error");
                }
                return RedirectToAction("Login", "Account");

            }
            else
            {
                ViewBag.Title = "Đăng ký tài khoản";
            }
            return View(model);
        }
        [Route("verify-email/{activeCode}")]
        public ActionResult VerifyEmail(string activeCode)
        {
            bool status = false;
            var verifyAccount = unitOfWork.AccountRepository.Get(a => a.ActiveCode == new Guid(activeCode) && a.IsActive == false).FirstOrDefault();
            if (verifyAccount != null)
            {
                try
                {
                    verifyAccount.IsActive = true;
                    unitOfWork.AccountRepository.Update(verifyAccount);
                    unitOfWork.Save();
                    status = true;
                    ViewBag.Message = "Kích hoạt tài khoản thành công";
                    ViewBag.Status = status;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Tài khoản không được kích hoạt";
                    ViewBag.Status = status;
                }

            }
            else
            {
                ViewBag.Status = status;
                ViewBag.Message = "Tài khoản không được kích hoạt";
            }
            return View();
        }

        private void SendEmail(string email, string subject, string url, string bodyText)
        {
            string link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);
            MailAddress toEmail = new MailAddress(email);
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("trangiathinh190697@gmail.com", "Nhà sách MyBookStore");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = "<br/><br/>" + bodyText +
                "<br/><br/><a href='" + link + "'>" + link + "</a>";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("trangiathinh190697@gmail.com", "thinh190697");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
        [AreaAuthorize("Customer")]
        [Route("view-account-information")]
        public ViewResult ViewAccountInformation()
        {
            ViewBag.Title = "Thông tin tài khoản";
            //get customer infor
            string email = HttpContext.User.Identity.Name;
            CustomerViewModel customer = unitOfWork.CustomerRepository.Get(c => c.Email == email)
                    .Select(c => new CustomerViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Address = c.Address,
                        BirthDate = c.BirthDate,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber
                    }).FirstOrDefault();
            //get order by customer id
            List<OrderViewModel> orders = unitOfWork.OrderRepository.Get(o => o.CustomerId == customer.Id, null, "OrderDetail,OrderStatus").Select(
                o => new OrderViewModel
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    DeliveryId = o.DeliveryId,
                    TotalPriceOrder = o.TotalPriceOrder,
                    CreatedDate = o.CreatedDate,
                    DeliveryDate = o.DeliveryDate,
                    OrderDetail = o.OrderDetail,
                    OrderStatus = o.OrderStatus
                }).ToList();
            ViewBag.Orders = orders;
            return View(customer);
        }
        [HttpPost]
        [Route("update-infor")]
        [AreaAuthorize("Customer")]
        public string UpdateAccountInfor(CustomerViewModel model)
        {
            var customer = unitOfWork.CustomerRepository.Get(c => c.Email == model.Email).FirstOrDefault();
            customer.Address = model.Address;
            customer.PhoneNumber = model.PhoneNumber;
            customer.Name = model.Name;
            try
            {
                unitOfWork.CustomerRepository.Update(customer);
                unitOfWork.Save();
                return "Cập nhật thành công!";
            }
            catch (Exception ex)
            {
                unitOfWork.Dispose();
                return "";
            }
        }
        [Route("view-order-detail/{orderId}")]
        [AreaAuthorize("Customer")]
        public JsonResult GetOrderDetail(string orderId)
        {
            string email = HttpContext.User.Identity.Name;
            Guid customerId = unitOfWork.CustomerRepository.Get(c => c.Email == email).FirstOrDefault().Id;
            List<OrderDetailViewModel> orderDetails = unitOfWork.OrderDetailRepository.Get(o => o.Order.CustomerId == customerId && o.OrderId == new Guid(orderId), null, "Book")
                                            .Select(o => new OrderDetailViewModel
                                            {
                                                Id = o.Id,
                                                BookId = o.BookId,
                                                Image = o.Book.ImagePath,
                                                OrderId = o.OrderId,
                                                OrderQuantity = o.OrderQuantity,
                                                Title = o.Book.Title,
                                                TotalPrice = o.Book.Price * o.OrderQuantity,
                                                Price = o.Book.Price,
                                            }).ToList();
            Order order = unitOfWork.OrderRepository.Get(o => o.Id == new Guid(orderId), null, includeProperties: "Delivery").FirstOrDefault();
            string deliveryAddress = order.Delivery.DeliveryAddress;
            string receiver = order.Delivery.ReceiverName;
            //ViewBag.DeliveryAddress = deliveryAddress;
            //ViewBag.Receiver = receiver;
            return Json(new { orderDetails, deliveryAddress, receiver }, JsonRequestBehavior.AllowGet);
        }
        [Route("forgot-password")]
        public ActionResult ForgotPassword()
        {
            ViewBag.Title = "Quên mật khẩu";
            return View();
        }
        [HttpPost]
        [Route("forgot-password")]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = unitOfWork.AccountRepository.Get(a => a.Email == model.Email).FirstOrDefault();
                if (account != null)
                {
                    //send email
                    try
                    {
                        SendEmail(model.Email, "Khôi phục tài khoản", "/account/customer/recovery-account/" + account.Id, "Vui lòng click vào link bên dưới để khôi phục tài khoản!");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Title = "Quên mật khẩu";
                    }
                }
                else
                {
                    ViewBag.Title = "Quên mật khẩu";
                    ModelState.AddModelError("IncorrectEmail", "Email không phải email đăng ký tài khoản!");
                    return View(model);
                }
            }
            else
            {
                ViewBag.Title = "Quên mật khẩu";
                return View(model);
            }
            TempData["Message"] = "Vui lòng kiểm tra email để khôi phục tài khoản";
            return View(model);
        }
        [Route("recovery-account/{id}")]
        public ActionResult RecoveryAccount(string id)
        {
            var account = unitOfWork.AccountRepository.GetById(new Guid(id));
            if (account != null)
            {
                ViewBag.Title = "Khôi phục tài khoản";
                return View();
            }
            ViewBag.Error = "Không tồn tại tài khoản!";
            return View("Error");
        }
        [HttpPost]
        [Route("recovery-account/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult RecoveryAccount(string id, RecoveryAccountViewModel model)
        {
            ViewBag.Title = "Kết quả";
            if (ModelState.IsValid)
            {
                var account = unitOfWork.AccountRepository.GetById(new Guid(id));
                if (account != null)
                {
                    account.PasswordHash = Crypto.SHA256(model.Password + account.Salt);
                    try
                    {
                        unitOfWork.AccountRepository.Update(account);
                        unitOfWork.Save();
                        ViewBag.Status = true;
                        return View("RecoveryAccountResult");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Status = false;
                        return View("RecoveryAccountResult");
                    }
                }
                ViewBag.Error = "Không tồn tại tài khoản!";
                return View("Error");
            }
            else
            {
                return View();
            }

        }
    }

}