using Microsoft.EntityFrameworkCore;
using MyBookStore.Infrastructure;
using MyBookStore.Models;
using MyBookStore.Repository;
using MyBookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBookStore.Areas.Admin
{
    public class AccountController : Controller
    {
        private IUnitOfWork unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Account account = unitOfWork.AccountRepository.Login(model);
                if (account != null )
                {
                    bool flag = false;
                    List<string> roleNames = unitOfWork.Context.AccountRole.Where(r => r.AccountId == account.Id).Include(r=>r.Role).Select(r=>r.Role.RoleName).ToList();
                    foreach(var roleName in roleNames)
                    {
                        if (roleName == "Admin")
                        {
                            flag = true;
                            break;
                        }
                    }
                    
                    if (flag) //account is admin
                    {
                        string roleNamesString = string.Join("|", roleNames);
                        int timeout = model.RememberMe ? 20 : 10;
                        var ticket = new FormsAuthenticationTicket(1, account.Email, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(timeout), model.RememberMe, roleNamesString);
                        string encrypt = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
                        cookie.Expires = DateTime.UtcNow.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        HttpContext.Response.Cookies.Add(cookie);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }

            return View();
        }
        [AreaAuthorize("Admin", Roles = "Admin")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AreaAuthorize("Admin",Roles ="Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account acc = new Account();
                acc.Id = Guid.NewGuid();
                acc.IsActive = true;
                acc.Salt = SaltHelper.GenerateSalt(10);
                acc.PasswordHash = Crypto.SHA256(model.Password+acc.Salt);
                acc.Email = model.Email;
                acc.ActiveCode = Guid.NewGuid();
                Role adminRole = unitOfWork.RoleRepository.Get(r => r.RoleName == "Admin").First();
                Customer customer = new Customer();
                customer.Id = Guid.NewGuid();
                customer.Name = model.Name;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Email = model.Email;
                customer.CreatedDate = DateTime.UtcNow;
                customer.BirthDate = model.Birthday;
                customer.Address = model.Address;
                customer.Gender = "Nam";
                acc.CustomerId = customer.Id;
                try
                {
                    unitOfWork.CustomerRepository.Create(customer);
                    unitOfWork.AccountRepository.Create(acc);
                    unitOfWork.Context.AccountRole.Add(new AccountRole { AccountId = acc.Id, RoleId = adminRole.Id });
                    unitOfWork.Save();
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    unitOfWork.Dispose();
                    return View();
                }
            }
            
            
            return View();
        }
    }
}