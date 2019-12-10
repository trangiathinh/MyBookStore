using System;
using System.Collections.Generic;
using System.Text;
using MyBookStore.Models;

namespace MyBookStore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Book> BookRepository { get; }
        public IRepository<Customer> CustomerRepository { get; }
        public IAccountRepository AccountRepository { get; }

       

        private MyBookStoreContext context;
        public UnitOfWork()
        {
            context = new MyBookStoreContext();
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
