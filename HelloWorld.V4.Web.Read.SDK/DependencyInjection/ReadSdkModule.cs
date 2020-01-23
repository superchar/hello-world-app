

using Autofac;

namespace HelloWorld.V4.Web.Read.SDK.DependencyInjection
{
    public class ReadSdkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HelloWorldClient>().As<IHelloWorldClient>();
        }
    }
}
