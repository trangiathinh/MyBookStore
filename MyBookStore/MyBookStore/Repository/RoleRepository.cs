using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(MyBookStoreContext context) : base(context)
        {

        }
    }
}