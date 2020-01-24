using Autofac;
using Autofac.Integration.Mvc;
using HelloWorld.V3.Domain;
using HelloWorld.V3.Infrastructure;
using System.Web.Mvc;

namespace HelloWorld.V3.App_Start
{
    public class ContainerConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<HelloWorldRepository>().As<IHelloWorldRepository>();

            builder.RegisterType<HelloWorldService>().As<IHelloWorldService>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}