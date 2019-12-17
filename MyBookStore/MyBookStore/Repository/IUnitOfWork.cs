using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookStore.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IAccountRepository AccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IBookTypeRepository BookTypeRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        MyBookStoreContext Context { get; }
        void Save();
    }
}
