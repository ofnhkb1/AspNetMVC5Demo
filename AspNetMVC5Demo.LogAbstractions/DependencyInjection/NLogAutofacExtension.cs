using Autofac;

namespace AspNetMVC5Demo.LogAbstractions.DependencyInjection
{
    public static class NLogAutofacExtension
    {
        public static ContainerBuilder AddNLog(this ContainerBuilder builder)
        {
            builder.RegisterType<CustomLogFactory>().As<ICustomLogFactory>().SingleInstance();

            return builder;
        }
    }
}