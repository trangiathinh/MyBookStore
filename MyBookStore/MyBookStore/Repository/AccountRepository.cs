using MyBookStore.Models;
using MyBookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace MyBookStore.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(MyBookStoreContext context):base(context)
        {
            
        }

        public bool IsUniqueEmail(string email)
        {
            var account = Get(p => p.Email == email);
            return account == null;
        }

        public bool Login(LoginViewModel model)
        {
            string passwordHash = Crypto.HashPassword(model.Password);
            
            var account = Get(p => p.Email == model.Email && p.PasswordHash == passwordHash);
            if (account!=null)
            {
                return true;
            }
            return false;
        }
    }
}