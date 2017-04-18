using System;
using System.Reflection;

using Autofac;
using Autofac.Integration.Mvc;

namespace AspNetMVC5Demo.Web.DependencyInjection
{
    public static class MvcControllerAutofacExtension
    {
        public static ContainerBuilder AddMvcControllers(this ContainerBuilder builder)
            => builder.AddMvcControllers(
            new Assembly[] { Assembly.Load("AspNetMVC5Demo.Web"), });

        public static ContainerBuilder AddMvcControllers(this ContainerBuilder builder, Func<Type, bool> predicate)
            => builder.AddMvcControllers(predicate, new Assembly[] { Assembly.Load("AspNetMVC5Demo.Web"), });

        public static ContainerBuilder AddMvcControllers(this ContainerBuilder builder,
            params Assembly[] controllerAssemblies)
            => AddMvcControllers(builder, null, controllerAssemblies);

        public static ContainerBuilder AddMvcControllers(this ContainerBuilder builder, Func<Type, bool> predicate, params Assembly[] controllerAssemblies)
        {
            if (predicate != null)
            {
                builder.RegisterControllers(controllerAssemblies)
                    .Where(predicate);

                return builder;
            }

            builder.RegisterControllers(controllerAssemblies);

            return builder;
        }
    }
}