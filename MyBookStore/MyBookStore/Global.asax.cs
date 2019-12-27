using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MyBookStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
        }
        public override void Init()
        {

            base.PostAuthenticateRequest += OnAfterAuthenticateRequest;
        }
        private void OnAfterAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //get cookie
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                var decodeTicket = FormsAuthentication.Decrypt(cookie.Value);
                string[] roles = decodeTicket.UserData.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var principle = new GenericPrincipal(HttpContext.Current.User.Identity, roles);
                HttpContext.Current.User = principle;
            }
        }
    }
}
