using AspNetMVC5Demo.Domian.Repository.AbortTask;
using AspNetMVC5Demo.Domian.Repository.Account;
using AspNetMVC5Demo.Infrastructure.Repository.AbortTask;
using AspNetMVC5Demo.Infrastructure.Repository.Account;

using Autofac;

namespace AspNetMVC5Demo.Infrastructure.DependencyInjection
{
    public static class RepositoryAutofacExtension
    {
        public static ContainerBuilder AddRepository(this ContainerBuilder builder)
        {
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<AbortTaskRepository>().As<IAbortTaskRepository>();

            return builder;
        }
    }
}