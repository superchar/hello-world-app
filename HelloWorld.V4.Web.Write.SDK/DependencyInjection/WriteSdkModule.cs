

using Autofac;

namespace HelloWorld.V4.Web.Write.SDK.DependencyInjection
{
    public class WriteSdkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HelloWorldClient>().As<IHelloWorldClient>();
        }
    }
}
