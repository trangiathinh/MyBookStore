using Microsoft.EntityFrameworkCore;
using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private MyBookStoreContext context;
        public AuthorRepository(MyBookStoreContext context) : base(context)
        {
            this.context = context;
        }

        public List<Author> GetAuthorsByBookId(Guid bookId)
        {
            List<Author> authors = context.BookAuthor.Where(ba => ba.BookId == bookId).Include(ba => ba.Author).
                Select(ba => ba.Author).ToList();
            return authors;
        }
    }
}