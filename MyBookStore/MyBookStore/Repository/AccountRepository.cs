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
        public AccountRepository(MyBookStoreContext context) : base(context)
        {

        }

        public bool IsUniqueEmail(string email)
        {
            var account = Get(p => p.Email == email);
            return account.ToList().Count == 0;
        }

        public Account Login(LoginViewModel model)
        {
            var account = Get(p => p.Email == model.Email,includeProperties:"Customer").FirstOrDefault();
            string salt = account.Salt;
            string passwordHash = Crypto.SHA256(model.Password + salt);

            if (account != null)
            {
                if (string.Compare(passwordHash, account.PasswordHash) == 0)
                {
                    return account;
                }
            }
            return null;
        }

    }
}