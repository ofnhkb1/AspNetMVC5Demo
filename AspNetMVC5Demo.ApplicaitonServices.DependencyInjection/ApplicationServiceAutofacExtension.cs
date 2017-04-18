using AspNetMVC5Demo.ApplicaitonServices.Interfaces;

using Autofac;

namespace AspNetMVC5Demo.ApplicaitonServices.DependencyInjection
{
    public static class ApplicationServiceAutofacExtension
    {
        public static ContainerBuilder AddApplicationService(this ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<AbortTaskService>().As<IAbortTaskService>();

            return builder;
        }
    }
}