using MyBookStore.Models;
using MyBookStore.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MyBookStore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterSingleton<MyBookStoreContext>();
            container.RegisterSingleton<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IBookTypeRepository, BookTypeRepository>();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IOrderDetailRepository, OrderDetailRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}