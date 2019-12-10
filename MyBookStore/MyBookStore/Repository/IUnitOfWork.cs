
using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookStore.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
        IAccountRepository AccountRepository { get; }
        void Save();
    }
}
