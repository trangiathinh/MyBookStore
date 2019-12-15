using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Repository
{
    public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
    {
        public BookTypeRepository(MyBookStoreContext context):base(context)
        {

        }
    }
}