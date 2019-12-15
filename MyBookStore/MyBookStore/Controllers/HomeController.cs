using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    [RoutePrefix("home")]
    
    public class HomeController : Controller
    {
        [Route]
        [Route("~/",Name ="Default")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [Route("about")]
        [Route("~/about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [Route("contact")]
        [Route("~/contact")]
        [Authorize(Roles ="Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}