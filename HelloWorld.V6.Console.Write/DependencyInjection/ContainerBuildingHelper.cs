

using Autofac;
using HelloWorld.V5.Write.Infrastructure.DependencyInjection;
using HelloWorld.V5.Write.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using HelloWorld.V4.Write.Domain;
using HelloWorld.V6.Write.Domain.Commands;
using HelloWorld.V6.Write.Domain.Handlers;

namespace HelloWorld.V6.Console.Write.DependencyInjection
{
    public static class ContainerBuildingHelper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<InfrastructureModule>();


            builder.RegisterType<HelloWorldEventRepository>().As<IHelloWorldRepository>();

            builder.RegisterType<CreateHelloWorldCommandHandler>().As<ICommandHandler<CreateHelloWorldCommand>>();

            return builder.Build();
        }
    }
}
