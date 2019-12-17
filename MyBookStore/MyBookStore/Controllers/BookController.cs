using MyBookStore.Repository;
using MyBookStore.ViewModels;
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
            var listBook = unitOfWork.BookRepository.Get().Select(b => new BookViewModel
            {
                Id=b.Id,
                IdPublisher=b.IdPublisher,
                BookTypeId=b.BookTypeId,
                Title=b.Title,
                ImagePath=b.ImagePath,
                Quantity=b.Quantity,
                Price=b.Price,
                DiscountPrice=b.DiscountPrice,
                NumberPages=b.NumberPages,
                PublishDate=b.PublishDate,
                StarsAverage=b.StarsAverage,
                Description=b.Description
            }).ToList();
            return View("Index", listBook);
        }
        [Route("detail/{id}")]
        public ActionResult Detail(string id)
        {
            var book= unitOfWork.BookRepository.Get(b=>b.Id==new Guid(id) && b.IsActive==true).Select(b => new BookViewModel
            {
                Id = b.Id,
                IdPublisher = b.IdPublisher,
                BookTypeId = b.BookTypeId,
                Title = b.Title,
                ImagePath = b.ImagePath,
                Quantity = b.Quantity,
                Price = b.Price,
                DiscountPrice = b.DiscountPrice,
                NumberPages = b.NumberPages,
                PublishDate = b.PublishDate,
                StarsAverage = b.StarsAverage,
                Description = b.Description,
            }).FirstOrDefault();
            //get authors by book id
            var authors = unitOfWork.AuthorRepository.GetAuthorsByBookId(book.Id).Select(a=>new AuthorViewModel
            {
                Id=a.Id,
                Name=a.Name,
                PhoneNumber=a.PhoneNumber,
                Email=a.Email,
                Address=a.Address,
                Birthday=a.Birthday,
                CreatedDate=a.CreatedDate
            });
            //save in ViewBag
            ViewBag.Authors = authors;
            //get books which are the same type
            var sameTypeBooks = unitOfWork.BookRepository.Get(b => b.BookTypeId == book.BookTypeId).Select(b=>new BookViewModel
            {
                Id = b.Id,
                IdPublisher = b.IdPublisher,
                BookTypeId = b.BookTypeId,
                Title = b.Title,
                ImagePath = b.ImagePath,
                Quantity = b.Quantity,
                Price = b.Price,
                DiscountPrice = b.DiscountPrice,
                NumberPages = b.NumberPages,
                PublishDate = b.PublishDate,
                StarsAverage = b.StarsAverage,
                Description = b.Description
            }).ToList();
            ViewBag.SameTypeBooks = sameTypeBooks;
            return View(book);
        }

    }
}