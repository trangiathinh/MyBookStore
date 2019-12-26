using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public Guid IdPublisher { get; set; }
        public Guid BookTypeId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int NumberPages { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double DiscountPrice { get; set; }
        public string Description { get; set; }
        public int StarsAverage { get; set; }
        //public PagingInfor Paging { get; set; }
        //public List<Author> Authors { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public bool? IsActive { get; set; }
    }
    public class PagingInfor
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling(TotalItems * 1.0 / ItemsPerPage); }
        }
    }
}