using Microsoft.AspNetCore.Mvc;
using MyBookStore.Repository;
using MyBookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    public class AccountController : Controller

    {
        private IUnitOfWork unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: Account
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //check account exist
                if (unitOfWork.AccountRepository.Login(model))
                {

                }
                else
                {
                    ModelState.AddModelError("", "Incorrect email or password!");
                }
            }
            else
            {
                //ModelState.AddModelError("","")
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}