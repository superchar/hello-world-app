using Autofac;
using Autofac.Integration.WebApi;
using HelloWorld.V6.Read.Domain;
using HelloWorld.V6.Read.Domain.Handlers;
using HelloWorld.V6.Read.Domain.Queries;
using HelloWorld.V6.Read.Infrastructure;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;

namespace HelloWorld.V6.App_Start
{
    public class ContainerConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<RavenHelloWorldRepository>().As<IHelloWorldRepository>();


            builder.RegisterType<HelloWorldGetAllQueryHandler>().As<IQueryHandler<HelloWorldGetAllQuery, List<HelloWorldQueryResult>>>();

            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}