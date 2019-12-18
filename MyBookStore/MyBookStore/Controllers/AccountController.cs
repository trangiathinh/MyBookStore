using Microsoft.AspNetCore.Mvc;
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
                    int timeout = model.RememberMe ? 20 : 1;
                    string roles = string.Join("|", account.AccountRole.ToList());
                    var ticket = new FormsAuthenticationTicket(1, account.Customer.Name, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(timeout), model.RememberMe, roles);
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
                        "/account/customer/verify-email/"+account.ActiveCode.ToString(), 
                        "Xin vui lòng click vào link bên dưới để kích hoạt tài khoản.");
                }
                catch(Exception ex)
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
                catch(Exception ex)
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

        private void SendEmail(string email,string subject, string url, string bodyText)
        {
            //string url = "/account/customer/verify-email/";
            string link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);
            //MailAddress fromEmail = new MailAddress("trangiathinh190697@gmail.com",);
            //string fromEmailPassword = "thinh190697";
            //string subject = "Tài khoản của bạn đã được tạo thành công";
            MailAddress toEmail = new MailAddress(email);

            //string body = 
            //SmtpClient smtpClient = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            //};
            //using (var message = new MailMessage(fromEmail, toEmail)
            //{
            //    Subject = subject,
            //    Body = body,
            //    IsBodyHtml = true
            //})
            //    smtpClient.Send(message);
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("trangiathinh190697@gmail.com", "Nhà sách MyBookStore");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = "<br/><br/>" + bodyText +
                "<br/><br/><a href='" + link + "'>" + link + "</a>";
                mail.IsBodyHtml = true;
               // mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("trangiathinh190697@gmail.com", "thinh190697");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
        [Authorize]
        [Route("show-information/{email}")]
        public ViewResult ShowInformation(string email)
        {
            return View();
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
                        SendEmail(model.Email, "Khôi phục tài khoản", "/account/customer/recovery-account/"+account.Id, "Vui lòng click vào link bên dưới để khôi phục tài khoản!");
                    }
                    catch(Exception ex)
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