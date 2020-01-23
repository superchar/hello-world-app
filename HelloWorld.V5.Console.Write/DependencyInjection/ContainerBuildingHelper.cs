

using Autofac;
using HelloWorld.V4.Write.Domain;
using HelloWorld.V5.Write.Infrastructure.DependencyInjection;
using HelloWorld.V4.Write.Infrastructure;
using HelloWorld.V5.Write.Infrastructure;
using HelloWorld.V5.Console.Write.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.V5.Console.Write.DependencyInjection
{
    public static class ContainerBuildingHelper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<InfrastructureModule>();

            builder.RegisterType<HelloWorldRepository>().As<IHelloWorldRepository>();

            builder.RegisterType<HelloWorldEventRepository>().As<IHelloWorldRepository>();

            builder.RegisterType<HelloWorldService>().As<IHelloWorldService>();

            builder.Register((c, type) => new HelloWorldRepositoryComposite(c.Resolve<IEnumerable<IHelloWorldRepository>>().ToArray())).As<IHelloWorldRepositoryComposite>();

            return builder.Build();
        }
    }
}
