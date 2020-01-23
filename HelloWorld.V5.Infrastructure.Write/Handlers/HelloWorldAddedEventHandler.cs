

using EventStore.ClientAPI;
using HelloWorld.V5.Write.Infrastructure.Events;
using System;
using System.Threading.Tasks;

namespace HelloWorld.V5.Write.Infrastructure.Handlers
{
    public class HelloWorldAddedEventHandler : IEventHandler<HelloWorldAddedEvent>
    {
        private const string StreamName = "HelloWorldApp";

        public async Task HandleAsync(HelloWorldAddedEvent targetEvent)
        {
            var conn = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:1113"), StreamName);
            await conn.ConnectAsync();
            await conn.AppendToStreamAsync(StreamName, ExpectedVersion.Any, ConvertToEventData(targetEvent));
        }

        private static EventData ConvertToEventData(HelloWorldAddedEvent helloWorldAddedEvent)
        {
            var data = Utf8Json.JsonSerializer.Serialize(helloWorldAddedEvent);
            return new EventData(Guid.NewGuid(), nameof(helloWorldAddedEvent), true, data, new byte[0]);
        }
    }
}
