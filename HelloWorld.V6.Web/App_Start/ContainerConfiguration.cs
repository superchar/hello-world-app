using Autofac;
using Autofac.Integration.Mvc;
using HelloWorld.V4.Web.Read.SDK.DependencyInjection;
using HelloWorld.V4.Web.Write.SDK.DependencyInjection;
using System.Web.Mvc;

namespace HelloWorld.V6.Web
{
    public class ContainerConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule<ReadSdkModule>();

            builder.RegisterModule<WriteSdkModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}