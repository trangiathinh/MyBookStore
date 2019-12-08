using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Book
    {
        public Book()
        {
            BookAuthor = new HashSet<BookAuthor>();
            OrderDetail = new HashSet<OrderDetail>();
            Rating = new HashSet<Rating>();
        }

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
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual BookType BookType { get; set; }
        public virtual Publisher IdPublisherNavigation { get; set; }
        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
