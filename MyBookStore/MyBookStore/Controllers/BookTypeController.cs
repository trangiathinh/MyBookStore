using MyBookStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    [RoutePrefix("book-type")]
    public class BookTypeController : Controller
    {
        private IUnitOfWork unitOfWork;
        public BookTypeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: BookType
        [Route()]
        public ActionResult Index()
        {
            ViewBag.Title = "Danh mục sách";
            return PartialView("_Index", unitOfWork.BookTypeRepository.GetAll().ToList());
        }
    }
}