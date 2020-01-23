

using Autofac;
using HelloWorld.V5.Write.Infrastructure.Events;
using HelloWorld.V5.Write.Infrastructure.Handlers;

namespace HelloWorld.V5.Write.Infrastructure.DependencyInjection
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HelloWorldAddedEventHandler>().As<IEventHandler<HelloWorldAddedEvent>>();
        }
    }
}
