using AspNetMVC5Demo.Domian.Model.Services;

using Autofac;

namespace AspNetMVC5Demo.Domian.Services.DependencyInjection
{
    public static class DomainServiceAutofacExtension
    {
        public static ContainerBuilder AddDomainService(this ContainerBuilder builder)
        {
            builder.RegisterType<ValidateTranslateDomianService>().As<IValidateTranslateDomianService>();

            return builder;
        }
    }
}