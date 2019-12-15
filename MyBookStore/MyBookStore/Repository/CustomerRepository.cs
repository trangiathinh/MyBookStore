using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MyBookStoreContext context) : base(context)
        {

        }
    }
}