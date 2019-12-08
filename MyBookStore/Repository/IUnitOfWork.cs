using EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
        void Save();
    }
}
