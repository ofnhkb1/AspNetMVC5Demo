using AspNetMVC5Demo.ApplicaitonServices.DependencyInjection;
using AspNetMVC5Demo.Domian.Services.DependencyInjection;
using AspNetMVC5Demo.Infrastructure.DependencyInjection;
using AspNetMVC5Demo.LogAbstractions.DependencyInjection;
using AspNetMVC5Demo.Web.DependencyInjection;

using Autofac;

namespace AspNetMVC5Demo.Web
{
    public class AutofacConfig
    {
        public static void Build()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.AddUnitOfWork();
            builder.AddDomainService();
            builder.AddRepository();
            builder.AddApplicationService();
            builder.AddNLog();
            builder.AddMvcControllers();

            var container = builder.Build();
            container.AddMvc5();
        }
    }
}