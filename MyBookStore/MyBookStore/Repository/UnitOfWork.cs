using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyBookStore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public IAccountRepository AccountRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public MyBookStoreContext Context { get; }

        public ICustomerRepository CustomerRepository { get; }

        public IBookTypeRepository BookTypeRepository { get; }

        public IAuthorRepository AuthorRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IOrderDetailRepository OrderDetailRepository { get; }

        public UnitOfWork(MyBookStoreContext context,
                          IAccountRepository accountRepository,
                          IRoleRepository roleRepository,
                          ICustomerRepository customerRepository,
                          IBookTypeRepository bookTypeRepository,
                          IBookRepository bookRepository,
                          IAuthorRepository authorRepository,
                          IOrderRepository orderRepository,
                          IOrderDetailRepository orderDetailRepository)
        {
            Context = context;
            this.AccountRepository = accountRepository;
            this.RoleRepository = roleRepository;
            this.CustomerRepository = customerRepository;
            this.BookTypeRepository = bookTypeRepository;
            this.BookRepository = bookRepository;
            this.AuthorRepository = authorRepository;
            this.OrderRepository = orderRepository;
            this.OrderDetailRepository = orderDetailRepository;
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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
            Context.SaveChanges();
        }
    }
}
