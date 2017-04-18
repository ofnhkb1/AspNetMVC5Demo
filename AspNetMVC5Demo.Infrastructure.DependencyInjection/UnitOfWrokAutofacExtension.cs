using AspNetMVC5Demo.Infrastructure.UnitOfWork;
using Autofac;

namespace AspNetMVC5Demo.Infrastructure.DependencyInjection
{
    public static class UnitOfWrokAutofacExtension
    {
        public static ContainerBuilder AddUnitOfWork(this ContainerBuilder builder)
        {
            // 将工作单元添加到当前作用域
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            return builder;
        }
    }
}