
using AutoMapper;
using HelloWorld.V4.Write.Domain;
using HelloWorld.V4.Write.Infrastructure;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HelloWorld.V4.Console.Write
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
                var service = GetService();
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body;
                    var helloWorld = Utf8Json.JsonSerializer.Deserialize<HelloWorldModel>(ea.Body);
                    await service.CreateAsync(helloWorld);
                };

                channel.BasicConsume(queue: "helloWorldQueue",
                                     autoAck: true,
                                     consumer: consumer);
                System.Console.WriteLine("Press any key to close");

                System.Console.ReadKey();
            }
        }

        private static IHelloWorldService GetService()
        {
            return new HelloWorldService(new HelloWorldRepository());
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(config => 
            {
                config.CreateMap<HelloWorldModel, V4.Write.Infrastructure.HelloWorld>();
            });
        }
    }
}
