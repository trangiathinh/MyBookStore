using Microsoft.EntityFrameworkCore;
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
        private int itemPerPage = 8;
        public BookController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: Book
        [Route()]
        public ActionResult Index(string bookTypeId="", int page=1)
        {
            IQueryable<BookViewModel> query = unitOfWork.BookRepository.Get().Select(b => new BookViewModel
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
            }).AsQueryable();
            string bookTypeName = "";
            if (!(bookTypeId == ""))
            {
                query = query.Where(book => book.BookTypeId == new Guid(bookTypeId)) ;
                var bookType = unitOfWork.BookTypeRepository.Get(bt => bt.Id == new Guid(bookTypeId)).FirstOrDefault();
                if (bookType != null)
                {
                    bookTypeName = bookType.BookTypeName;
                }
            }
            //total number pages
            int numberPages = (int)Math.Ceiling(query.Count()*1.0/itemPerPage);
            ViewBag.NumberPages = numberPages;
            ViewBag.CurrentPage = page;
            ViewBag.BookTypeId = bookTypeId;
            query = query.Skip((page - 1) * itemPerPage).Take(itemPerPage);
            ViewBag.Title = bookTypeName != "" ? bookTypeName : "Sản phẩm nổi bật";
            return View("Index", query.ToList());
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
            ViewBag.Title = "Chi tiết sách";
            return View(book);
        }

    }
}