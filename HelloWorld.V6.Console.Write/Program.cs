using Autofac;
using AutoMapper;
using HelloWorld.V4.Write.Domain;
using HelloWorld.V5.Write.Infrastructure.Events;
using HelloWorld.V6.Console.Write.DependencyInjection;
using HelloWorld.V6.Write.Domain.Commands;
using HelloWorld.V6.Write.Domain.Handlers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.V6.Console.Write
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureMapper();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var handler = GetHandler();
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body;
                    var helloWorldCommand = Utf8Json.JsonSerializer.Deserialize<CreateHelloWorldCommand>(ea.Body);
                    await handler.HandleAsync(helloWorldCommand);
                };

                channel.BasicConsume(queue: "helloWorldQueue",
                                     autoAck: true,
                                     consumer: consumer);
                System.Console.WriteLine("Press any key to close");

                System.Console.ReadKey();
            }
        }

        private static ICommandHandler<CreateHelloWorldCommand> GetHandler()
        {
            var container = ContainerBuildingHelper.BuildContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                return scope.Resolve<ICommandHandler<CreateHelloWorldCommand>>();
            }
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<HelloWorldModel, HelloWorldAddedEvent>();
            });
        }
    }
}
