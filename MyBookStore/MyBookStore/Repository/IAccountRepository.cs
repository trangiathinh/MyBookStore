using MyBookStore.Models;
using MyBookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        bool Login(LoginViewModel model);
        bool IsUniqueEmail(string email);
    }
}
