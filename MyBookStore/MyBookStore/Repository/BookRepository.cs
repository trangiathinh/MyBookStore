using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(MyBookStoreContext context) : base(context)
        {

        }
    }
}