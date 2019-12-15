using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Areas.Admin
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }
    }
}