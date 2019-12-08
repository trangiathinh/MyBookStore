using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;

namespace MyBookStore.Controllers
{
    public class BookController : Controller
    {
        private IUnitOfWork unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: Book
        public ActionResult Index()
        {
            
            return View("",unitOfWork.BookRepository.GetAll().ToList());
        }
    }
}