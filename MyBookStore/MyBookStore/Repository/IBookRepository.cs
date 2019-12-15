using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        //add more methods here
    }
}
