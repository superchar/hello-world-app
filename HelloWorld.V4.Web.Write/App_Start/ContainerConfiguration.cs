using Autofac;
using Autofac.Integration.WebApi;
using HelloWorld.V4.Write.Domain;
using HelloWorld.V4.Write.Infrastructure;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace HelloWorld.V4.App_Start
{
    public class ContainerConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<HelloWorldRepository>().As<IHelloWorldRepository>();

            builder.RegisterType<HelloWorldService>().As<IHelloWorldService>();

            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}