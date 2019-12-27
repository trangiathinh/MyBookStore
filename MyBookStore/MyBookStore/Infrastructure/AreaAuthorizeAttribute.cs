using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Infrastructure
{
    public class AreaAuthorizeAttribute:AuthorizeAttribute
    {
        private readonly string area;
        public AreaAuthorizeAttribute(string area)
        {
            this.area = area;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string loginUrl = "";
            switch (area)
            {
                case "Admin":
                    {
                        loginUrl = "~/Admin/Account/Login";
                        break;
                    }
                case "Customer":
                    {
                        loginUrl = "~/account/customer/login";
                        break;
                    }
            }
            filterContext.Result = new RedirectResult(loginUrl + "?returnUrl=" + Uri.UnescapeDataString(filterContext.HttpContext.Request.Url.PathAndQuery));
            
        }
    }
}