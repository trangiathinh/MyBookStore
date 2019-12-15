using MyBookStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyBookStore.Controllers
{
    [RoutePrefix("books")]
    public class BookController : Controller
    {
        private IUnitOfWork unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: Book
        [Route()]
        public ActionResult Index()
        {
            return View("Index", unitOfWork.BookRepository.GetAll().ToList());
        }
        [Route("detail/{id}")]
        public ActionResult Detail(string id)
        {
            return View();
        }

    }
}