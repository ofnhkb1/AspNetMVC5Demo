using Autofac;
using Autofac.Integration.Mvc;

namespace AspNetMVC5Demo.Web.DependencyInjection
{
    public static class MvcAutofacExtension
    {
        public static void AddMvc5(this IContainer container)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
