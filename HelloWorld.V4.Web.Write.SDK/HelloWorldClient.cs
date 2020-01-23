

using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.V4.Web.Write.SDK
{
    public class HelloWorldClient : IHelloWorldClient
    {
        public Task<HelloWorldDto> CreateAsync(HelloWorldDto helloWorldDto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(helloWorldDto));

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "helloWorldQueue",
                                     basicProperties: null,
                                     body: body);
            }

            return Task.FromResult(helloWorldDto);
        }
    }
}
